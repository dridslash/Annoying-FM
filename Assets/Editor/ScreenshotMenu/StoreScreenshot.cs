#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.Recorder;
using UnityEditor.Recorder.Input;
using UnityEngine;

public static class StoreScreenshot
{

    [MenuItem("Hoptimist/Store Screenshots %&i")]
    public static void TakeSS()
    {
        recordInSeq();
    }

    static async void recordInSeq()
    {
        var android = Record("1920x1080");
        while (android.IsRecording())
        {
            await Task.Delay(50);
        }

        var inch67 = Record("6.7 inch");
        while (inch67.IsRecording())
        {
            await Task.Delay(50);
        }

        var inch55 = Record("5.5 inch");
        while (inch55.IsRecording())
        {
            await Task.Delay(50);
        }

        var inch129 = Record("12.9 inch");
        while (inch129.IsRecording())
        {
            await Task.Delay(50);
        }
    }

    public static RecorderController Record(string deviceName)
    {
        var controllerSettings = ScriptableObject.CreateInstance<RecorderControllerSettings>();
        var recorderController = new RecorderController(controllerSettings);

        // Image sequence
        var imageRecorder = ScriptableObject.CreateInstance<ImageRecorderSettings>();
        imageRecorder.name = "My Image Recorder" + deviceName;
        imageRecorder.Enabled = true;
        imageRecorder.OutputFormat = ImageRecorderSettings.ImageRecorderOutputFormat.PNG;
        imageRecorder.CaptureAlpha = false;

        // 6.5 inch (If 6.7 is provided then 6.5 is unecessary. Also, 6.7 is closer to 1920x1080 than 6.5)
        // 2688 x 1242 pixel

        // 5.5inch
        // 2208 x 1242 pixels

        // 12.9inch
        // 2732 x 2048 pixels

        // optional:
        // 6.7inch
        // 2796 x 1290

        var res = new Dictionary<string, int[]>();
        res["1920x1080"] = new int[] { 1920, 1080 };
        res["6.7 inch"] = new int[] { 2796, 1290 };
        // res["2 - 6.5inch (Optional)"] = new int[] { 2688, 1242 };
        res["5.5 inch"] = new int[] { 2208, 1242 };
        res["12.9 inch"] = new int[] { 2732, 2048 };


        var mediaOutputFolder = Path.Combine(Application.dataPath, "..", "SampleRecordings/" + deviceName);
        string hourMinute = DateTime.Now.ToString("HH_mm_ss");
        imageRecorder.OutputFile = Path.Combine(mediaOutputFolder, "image_") + hourMinute;

        imageRecorder.imageInputSettings = new GameViewInputSettings
        {
            OutputWidth = res[deviceName][0],
            OutputHeight = res[deviceName][1],
        };

        // Setup Recording
        controllerSettings.AddRecorderSettings(imageRecorder);
        controllerSettings.SetRecordModeToSingleFrame(0);
        recorderController.PrepareRecording();
        recorderController.StartRecording();
        return recorderController;
    }
}

#endif