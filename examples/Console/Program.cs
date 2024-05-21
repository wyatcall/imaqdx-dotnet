using System;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Acquisition.Imaqdx;

namespace ConsoleExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool testResult = true;
            try
            {
                ImaqdxCameraInformation[] cameraList = ImaqdxSystem.GetCameraInformation(true);

                foreach (ImaqdxCameraInformation la in cameraList)
                {
                    var session = new ImaqdxSession(la.Name);
                    session.ConfigureGrab();

                    VisionImage image = new VisionImage();

                    session.Grab(null, true, out uint bufferNumber);

                    image.WritePngFile(la.Name + ".png");
                }

            }
            catch(ArgumentNullException e)
            {
                testResult = false;
            }
            finally
            {

            }
        }
    }
}
