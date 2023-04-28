using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace RunBatchFileWithoutTerminal
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length is 0)
            {
                DisplayErrorMessage("Missing Argument: Path to target batch file.");
                return;
            }

            string batchFilePath = args[0];

            if (!File.Exists(batchFilePath))
            {
                DisplayErrorMessage($"File '{batchFilePath}' does not exist.");
                return;
            }

            if (Path.GetExtension(batchFilePath).ToLower() != ".bat")
            {
                DisplayErrorMessage($"File '{batchFilePath}' is not a batch file.");
                return;
            }

            ProcessStartInfo startInfo = new()
            {
                FileName = batchFilePath,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            using Process? batchProcess = Process.Start(startInfo);
            batchProcess?.Dispose();
        }

        private static void DisplayErrorMessage(string message)
        {
            MessageBox.Show(message, "RunBatchFileWithoutTerminal", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}