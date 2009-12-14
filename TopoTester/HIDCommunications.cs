using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices; 

namespace GenericHid
{
    class HIDCommunications
    {
        private Boolean myDeviceDetected;
        private Debugging MyDebugging = new Debugging();
        private DeviceManagement MyDeviceManagement = new DeviceManagement();
        private SafeFileHandle hidHandle;
        private Hid MyHid = new Hid();
        private String myDevicePathName;
        private IntPtr deviceNotificationHandle;
        private IntPtr FormHandle;
        private String hidUsage;
        private SafeFileHandle readHandle;
        private SafeFileHandle writeHandle;
        private Boolean exclusiveAccess;

        static private HIDCommunications instance = null;

        private HIDCommunications(/*ref IntPtr fH*/)
        {
            /*FormHandle = fH;*/
            myDeviceDetected = false;
        }

        public static HIDCommunications getInstance(/*ref IntPtr formHandle*/)
        {
            if (instance == null)
                instance = new HIDCommunications(/*ref this.FormHandle*/);
            return instance;
        }

        public Boolean FindTheHid(Int16 myVendorID, Int16 myProductID)
        {
            Boolean deviceFound = false;
            String[] devicePathName = new String[128];
            String functionName = "";
            Guid hidGuid = Guid.Empty;
            Int32 memberIndex = 0;

            Boolean success = false;

            try
            {
                myDeviceDetected = false;

                //  ***
                //  API function: 'HidD_GetHidGuid

                //  Purpose: Retrieves the interface class GUID for the HID class.

                //  Accepts: 'A System.Guid object for storing the GUID.
                //  ***

                Hid.HidD_GetHidGuid(ref hidGuid);

                functionName = "GetHidGuid";
                Debug.WriteLine(MyDebugging.ResultOfAPICall(functionName));
                Debug.WriteLine("  GUID for system HIDs: " + hidGuid.ToString());

                //  Fill an array with the device path names of all attached HIDs.

                deviceFound = MyDeviceManagement.FindDeviceFromGuid(hidGuid, ref devicePathName);

                //  If there is at least one HID, attempt to read the Vendor ID and Product ID
                //  of each device until there is a match or all devices have been examined.

                int times_found = 0;

                if (deviceFound)
                {
                    memberIndex = 0;

                    do
                    {
                        //  ***
                        //  API function:
                        //  CreateFile

                        //  Purpose:
                        //  Retrieves a handle to a device.

                        //  Accepts:
                        //  A device path name returned by SetupDiGetDeviceInterfaceDetail
                        //  The type of access requested (read/write).
                        //  FILE_SHARE attributes to allow other processes to access the device while this handle is open.
                        //  A Security structure or IntPtr.Zero. 
                        //  A creation disposition value. Use OPEN_EXISTING for devices.
                        //  Flags and attributes for files. Not used for devices.
                        //  Handle to a template file. Not used.

                        //  Returns: a handle without read or write access.
                        //  This enables obtaining information about all HIDs, even system
                        //  keyboards and mice. 
                        //  Separate handles are used for reading and writing.
                        //  ***

                        hidHandle = FileIO.CreateFile(devicePathName[memberIndex], 0, FileIO.FILE_SHARE_READ | FileIO.FILE_SHARE_WRITE, IntPtr.Zero, FileIO.OPEN_EXISTING, 0, 0);

                        functionName = "CreateFile";
                        Debug.WriteLine(MyDebugging.ResultOfAPICall(functionName));
                        Debug.WriteLine("  Returned handle: " + hidHandle.ToString());

                        if (!hidHandle.IsInvalid)
                        {
                            //  The returned handle is valid, 
                            //  so find out if this is the device we're looking for.

                            //  Set the Size property of DeviceAttributes to the number of bytes in the structure.

                            MyHid.DeviceAttributes.Size = Marshal.SizeOf(MyHid.DeviceAttributes);

                            //  ***
                            //  API function:
                            //  HidD_GetAttributes

                            //  Purpose:
                            //  Retrieves a HIDD_ATTRIBUTES structure containing the Vendor ID, 
                            //  Product ID, and Product Version Number for a device.

                            //  Accepts:
                            //  A handle returned by CreateFile.
                            //  A pointer to receive a HIDD_ATTRIBUTES structure.

                            //  Returns:
                            //  True on success, False on failure.
                            //  ***                            

                            success = Hid.HidD_GetAttributes(hidHandle, ref MyHid.DeviceAttributes);

                            if (success)
                            {
                                Debug.WriteLine("  HIDD_ATTRIBUTES structure filled without error.");
                                Debug.WriteLine("  Structure size: " + MyHid.DeviceAttributes.Size);
                                Debug.WriteLine("  Vendor ID: " + Convert.ToString(MyHid.DeviceAttributes.VendorID, 16));
                                Debug.WriteLine("  Product ID: " + Convert.ToString(MyHid.DeviceAttributes.ProductID, 16));
                                Debug.WriteLine("  Version Number: " + Convert.ToString(MyHid.DeviceAttributes.VersionNumber, 16));

                                //  Find out if the device matches the one we're looking for.

                                if ((MyHid.DeviceAttributes.VendorID == myVendorID) && (MyHid.DeviceAttributes.ProductID == myProductID))
                                {

                                    Debug.WriteLine("  My device detected");

                                    //  Display the information in form's list box.

                                    Debug.WriteLine("Device detected:");
                                    Debug.WriteLine("  Vendor ID= " + Convert.ToString(MyHid.DeviceAttributes.VendorID, 16));
                                    Debug.WriteLine("  Product ID = " + Convert.ToString(MyHid.DeviceAttributes.ProductID, 16));

                                    //times_found++;
                                    //if(times_found == 3)
                                    myDeviceDetected = true;

                                    //  Save the DevicePathName for OnDeviceChange().

                                    myDevicePathName = devicePathName[memberIndex];
                                }
                                else
                                {
                                    //  It's not a match, so close the handle.

                                    myDeviceDetected = false;
                                    hidHandle.Close();
                                }
                            }
                            else
                            {
                                //  There was a problem in retrieving the information.

                                Debug.WriteLine("  Error in filling HIDD_ATTRIBUTES structure.");
                                myDeviceDetected = false;
                                hidHandle.Close();
                            }
                        }

                        //  Keep looking until we find the device or there are no devices left to examine.

                        memberIndex = memberIndex + 1;
                    }
                    while (!((myDeviceDetected || (memberIndex == devicePathName.Length))));
                }

                if (myDeviceDetected)
                {
                    //  The device was detected.
                    //  Register to receive notifications if the device is removed or attached.

                    //success = true;
                    success = MyDeviceManagement.RegisterForDeviceNotifications(myDevicePathName, FormHandle, hidGuid, ref deviceNotificationHandle);

                    Debug.WriteLine("RegisterForDeviceNotifications = " + success);

                    //  Learn the capabilities of the device.

                    MyHid.Capabilities = MyHid.GetDeviceCapabilities(hidHandle);

                    if (success)
                    {
                        //  Find out if the device is a system mouse or keyboard.

                        hidUsage = MyHid.GetHidUsage(MyHid.Capabilities);

                        //  Get the Input report buffer size.

                        GetInputReportBufferSize();

                        //  Get handles to use in requesting Input and Output reports.

                        readHandle = FileIO.CreateFile(myDevicePathName, FileIO.GENERIC_READ, FileIO.FILE_SHARE_READ | FileIO.FILE_SHARE_WRITE, IntPtr.Zero, FileIO.OPEN_EXISTING, FileIO.FILE_FLAG_OVERLAPPED, 0);

                        functionName = "CreateFile, ReadHandle";
                        Debug.WriteLine(MyDebugging.ResultOfAPICall(functionName));
                        Debug.WriteLine("  Returned handle: " + readHandle.ToString());

                        if (readHandle.IsInvalid)
                        {
                            exclusiveAccess = true;
                            Debug.WriteLine("The device is a system " + hidUsage + ".");
                            Debug.WriteLine("Windows 2000 and Windows XP obtain exclusive access to Input and Output reports for this devices.");
                            Debug.WriteLine("Applications can access Feature reports only.");
                        }
                        else
                        {
                            writeHandle = FileIO.CreateFile(myDevicePathName, FileIO.GENERIC_WRITE, FileIO.FILE_SHARE_READ | FileIO.FILE_SHARE_WRITE, IntPtr.Zero, FileIO.OPEN_EXISTING, 0, 0);

                            functionName = "CreateFile, WriteHandle";
                            Debug.WriteLine(MyDebugging.ResultOfAPICall(functionName));
                            Debug.WriteLine("  Returned handle: " + writeHandle.ToString());

                            //  Flush any waiting reports in the input buffer. (optional)

                            MyHid.FlushQueue(readHandle);
                        }
                    }
                }
                else
                {
                    //  The device wasn't detected.

                    Debug.WriteLine("Device not found.");

                }
                return myDeviceDetected;
            }
            catch (Exception ex)
            {
                // TODO
                throw;
            }
        }

        // GET FEATURE REPORT ====================================================================================
        public Boolean GetFeatureReport(Byte reportID, ref Byte[] data, Int32 dataLength)
        {
            String byteValue = null;
            Int32 count = 0;
            Byte[] inFeatureReportBuffer = null;
            Boolean success = false;

            if (myDeviceDetected == false)
                return false;

            try
            {
                Hid.InFeatureReport myInFeatureReport = new Hid.InFeatureReport();

                if ((MyHid.Capabilities.FeatureReportByteLength > 0))
                {
                    inFeatureReportBuffer = new Byte[dataLength + 1];

                    //  Read a report.

                    inFeatureReportBuffer[0] = reportID;

                    myInFeatureReport.Read(hidHandle, readHandle, writeHandle, ref myDeviceDetected, ref inFeatureReportBuffer, ref success);

                    if (success)
                    {
                        Debug.WriteLine("A Feature report has been read.");

                        for (count = 1; count < inFeatureReportBuffer.Length; count++)
                            data[count - 1] = inFeatureReportBuffer[count];

                        //  Display the report data received in the form's list box.

                        Debug.WriteLine(" Feature Report ID: " + String.Format("{0:X2} ", inFeatureReportBuffer[0]));
                        Debug.WriteLine(" Feature Report Data:");

                        for (count = 0; count <= inFeatureReportBuffer.Length - 1; count++)
                        {

                            //  Display bytes as 2-character Hex strings.

                            byteValue = String.Format("{0:X2} ", inFeatureReportBuffer[count]);

                            Debug.WriteLine(" " + byteValue);
                        }
                    }
                    else
                    {
                        Debug.WriteLine("The attempt to read a Feature report failed.");
                    }
                }
            }
            catch (Exception e)
            {
                // TODO
            }

            return success;
        }

        public Boolean SetFeatureReport(Byte reportID, Byte[] data, Int32 dataLength)
        {
            String byteValue = null;
            Int32 count = 0;
            Byte[] outFeatureReportBuffer = null;
            Boolean success = false;

            if (myDeviceDetected == false)
                return false;

            try
            {

                Hid.OutFeatureReport myOutFeatureReport = new Hid.OutFeatureReport();

                if ((MyHid.Capabilities.FeatureReportByteLength > 0))
                {

                    outFeatureReportBuffer = new Byte[dataLength + 1];

                    //  Store the report ID in the buffer

                    outFeatureReportBuffer[0] = reportID;

                    //  Store the report data following the report ID.

                    for (count = 1; count <= dataLength; count++)
                        outFeatureReportBuffer[count] = data[count - 1];

                    //  Write a report to the device

                    success = myOutFeatureReport.Write(outFeatureReportBuffer, hidHandle);

                    if (success)
                    {
                        Debug.WriteLine("A Feature report has been written.");

                        //  Display the report data sent in the form's list box.

                        Debug.WriteLine(" Feature Report ID: " + String.Format("{0:X2} ", outFeatureReportBuffer[0]));
                        Debug.WriteLine(" Feature Report Data:");

                        for (count = 0; count <= outFeatureReportBuffer.Length - 1; count++)
                        {
                            //  Display bytes as 2-character Hex strings.

                            byteValue = String.Format("{0:X2} ", outFeatureReportBuffer[count]);

                            Debug.WriteLine(" " + byteValue);
                        }
                    }
                    else
                    {
                        Debug.WriteLine("The attempt to write a Feature report failed.");
                    }
                }
            }
            catch (Exception e)
            {
                // TODO
                throw;
            }

            return success;
        }

        private void GetInputReportBufferSize()
        {
            Int32 numberOfInputBuffers = 0;
            Boolean success;

            try
            {

                success = MyHid.GetNumberOfInputBuffers(hidHandle, ref numberOfInputBuffers);
            }
            catch (Exception ex)
            {
                // TODO
                throw;
            }
        }     

    }
}
