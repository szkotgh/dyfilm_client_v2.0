using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dyfilm_client_v2._0.src
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Text;

    public class Camera
    {
        #region EDSDK Constants & Structs

        private const uint EDS_ERR_OK = 0x00000000;
        private const uint kEdsCameraCommand_TakePicture = 0x00000000;
        private const uint kEdsDataType_ByteBlock = 1;

        private const uint kEdsObjectEvent_DirItemCreated = 0x00000103;
        private const uint kEdsStateEvent_Shutdown = 0x00000209;
        private const uint kEdsPropertyEvent_All = 0x00000100;

        private const uint kEdsPropID_Evf_OutputDevice = 0x00000500;
        private const uint kEdsEvfOutputDevice_PC = 1;
        private const uint kEdsEvfOutputDevice_TFT = 2;

        private const uint kEdsPropID_Evf_Zoom = 0x00000501;
        private const uint kEdsPropID_Evf_ImagePosition = 0x00000502;
        private const uint kEdsPropID_Evf_Histogram = 0x00000503;

        private delegate uint EdsObjectEventHandler(uint inEvent, IntPtr inRef, IntPtr inContext);

        private delegate uint EdsStateEventHandler(uint inEvent, uint inParameter, IntPtr inContext);

        private delegate uint EdsPropertyEventHandler(uint inEvent, uint inPropertyID, uint inParameter, IntPtr inContext);

        [StructLayout(LayoutKind.Sequential)]
        public struct EdsDirectoryItemInfo
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string szFileName;
            public uint size;
            public int isFolder;
            public int groupID;
            public int option;
            public uint time;
        }

        #endregion

        #region EDSDK Function Imports

        [DllImport("EDSDK.dll")]
        private static extern uint EdsInitializeSDK();

        [DllImport("EDSDK.dll")]
        private static extern uint EdsTerminateSDK();

        [DllImport("EDSDK.dll")]
        private static extern uint EdsGetCameraList(out IntPtr cameraList);

        [DllImport("EDSDK.dll")]
        private static extern uint EdsGetChildCount(IntPtr inRef, out int outCount);

        [DllImport("EDSDK.dll")]
        private static extern uint EdsGetChildAtIndex(IntPtr inRef, int index, out IntPtr outRef);

        [DllImport("EDSDK.dll")]
        private static extern uint EdsOpenSession(IntPtr camera);

        [DllImport("EDSDK.dll")]
        private static extern uint EdsCloseSession(IntPtr camera);

        [DllImport("EDSDK.dll")]
        private static extern uint EdsSendCommand(IntPtr camera, uint command, int param);

        [DllImport("EDSDK.dll")]
        private static extern uint EdsSetObjectEventHandler(IntPtr camera, uint eventID, EdsObjectEventHandler handler, IntPtr context);

        [DllImport("EDSDK.dll")]
        private static extern uint EdsGetDirectoryItemInfo(IntPtr directoryItem, out EdsDirectoryItemInfo info);

        [DllImport("EDSDK.dll")]
        private static extern uint EdsDownload(IntPtr directoryItem, uint size, IntPtr stream);

        [DllImport("EDSDK.dll")]
        private static extern uint EdsDownloadComplete(IntPtr directoryItem);

        [DllImport("EDSDK.dll")]
        private static extern uint EdsRelease(IntPtr inRef);

        [DllImport("EDSDK.dll")]
        private static extern uint EdsCreateFileStream([MarshalAs(UnmanagedType.LPWStr)] string fileName, uint createDisposition, uint access, out IntPtr stream);

        [DllImport("EDSDK.dll")]
        private static extern uint EdsSetPropertyData(IntPtr inRef, uint propertyID, int param, uint dataSize, ref uint data);

        [DllImport("EDSDK.dll")]
        private static extern uint EdsGetPropertyData(IntPtr inRef, uint propertyID, int param, out uint data);

        [DllImport("EDSDK.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern uint EdsCreateMemoryStream(uint bufferSize, out IntPtr stream);

        [DllImport("EDSDK.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern uint EdsCreateEvfImageRef(IntPtr stream, out IntPtr evfImage);

        [DllImport("EDSDK.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern uint EdsDownloadEvfImage(IntPtr camera, IntPtr evfImage);


        #endregion

        private IntPtr camera = IntPtr.Zero;
        private IntPtr cameraList = IntPtr.Zero;

        public bool Initialize()
        {
            uint err = EdsInitializeSDK();
            if (err != EDS_ERR_OK) return false;

            err = EdsGetCameraList(out cameraList);
            if (err != EDS_ERR_OK) return false;

            int count = 0;
            err = EdsGetChildCount(cameraList, out count);
            if (count == 0 || err != EDS_ERR_OK) return false;

            err = EdsGetChildAtIndex(cameraList, 0, out camera);
            if (err != EDS_ERR_OK) return false;

            err = EdsOpenSession(camera);
            if (err != EDS_ERR_OK) return false;

            EdsSetObjectEventHandler(camera, kEdsObjectEvent_DirItemCreated, HandleObjectEvent, IntPtr.Zero);

            return true;
        }

        public void Terminate()
        {
            if (camera != IntPtr.Zero)
            {
                EdsCloseSession(camera);
                EdsRelease(camera);
            }

            if (cameraList != IntPtr.Zero)
            {
                EdsRelease(cameraList);
            }

            EdsTerminateSDK();
        }

        public void TakePhoto()
        {
            if (camera != IntPtr.Zero)
            {
                EdsSendCommand(camera, kEdsCameraCommand_TakePicture, 0);
            }
        }

        public void StartLiveView()
        {
            uint device = kEdsEvfOutputDevice_PC;
            EdsSetPropertyData(camera, kEdsPropID_Evf_OutputDevice, 0, sizeof(uint), ref device);
        }

        public void StopLiveView()
        {
            uint device = 0;
            EdsSetPropertyData(camera, kEdsPropID_Evf_OutputDevice, 0, sizeof(uint), ref device);
        }

        public Bitmap GetLiveViewImage()
        {
            IntPtr stream, evfImage;

            // 메모리 스트림 생성
            uint err = EdsCreateMemoryStream(2 * 1024 * 1024, out stream);
            if (err != EDS_ERR_OK || stream == IntPtr.Zero)
            {
                // 에러 발생 시 에러 코드 출력
                Console.WriteLine("Error occurred in EdsCreateMemoryStream: " + err);
                return null; // 스트림 생성에 실패한 경우 null 반환
            }

            // EVF 이미지 참조 생성
            err = EdsCreateEvfImageRef(stream, out evfImage);
            if (err != EDS_ERR_OK || evfImage == IntPtr.Zero)
            {
                EdsRelease(stream);
                return null; // EVF 이미지 참조 생성 실패 시 리소스 해제 후 null 반환
            }

            // EVF 이미지 다운로드
            err = EdsDownloadEvfImage(camera, evfImage);
            if (err != EDS_ERR_OK)
            {
                EdsRelease(evfImage);
                EdsRelease(stream);
                return null; // 다운로드 실패 시 리소스 해제 후 null 반환
            }

            try
            {
                // Canon의 메모리 스트림은 IStream 인터페이스 기반
                var iStream = (System.Runtime.InteropServices.ComTypes.IStream)Marshal.GetObjectForIUnknown(stream);
                using (var managedStream = new System.IO.MemoryStream())
                {
                    byte[] buffer = new byte[4096];
                    IntPtr bytesReadPtr = Marshal.AllocHGlobal(sizeof(int));

                    while (true)
                    {
                        // IStream에서 읽어오기
                        iStream.Read(buffer, buffer.Length, bytesReadPtr);
                        int bytesRead = Marshal.ReadInt32(bytesReadPtr);
                        if (bytesRead == 0)
                            break; // 읽을 데이터가 없으면 종료

                        managedStream.Write(buffer, 0, bytesRead);
                    }

                    // 메모리 해제
                    Marshal.FreeHGlobal(bytesReadPtr);

                    // 비트맵으로 변환
                    managedStream.Seek(0, System.IO.SeekOrigin.Begin);
                    return new Bitmap(managedStream);
                }
            }
            catch (Exception ex)
            {
                EdsRelease(evfImage);
                EdsRelease(stream);
                Console.WriteLine($"Error occurred: {ex.Message}");
                return null;
            }
            finally
            {
                // 리소스 해제
                EdsRelease(evfImage);
                EdsRelease(stream);
            }
        }



        private uint HandleObjectEvent(uint inEvent, IntPtr inRef, IntPtr inContext)
        {
            if (inEvent == kEdsObjectEvent_DirItemCreated)
            {
                EdsDirectoryItemInfo dirInfo;
                EdsGetDirectoryItemInfo(inRef, out dirInfo);

                string savePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dirInfo.szFileName);

                IntPtr stream;
                EdsCreateFileStream(savePath, 1, 3, out stream);

                EdsDownload(inRef, dirInfo.size, stream);
                EdsDownloadComplete(inRef);

                EdsRelease(stream);
                EdsRelease(inRef);
            }
            return EDS_ERR_OK;
        }
    }

}
