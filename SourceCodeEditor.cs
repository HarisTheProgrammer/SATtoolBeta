using System;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

//Source Code editor pane class
//Class to save output and load previous outputs.
//using a reader, will input the values into the Cyclomatric Reader and Halstead statistic

namespace StaticCodeAnalyser
{
    class SourceCodeEditor
    {
        private string _sourceCode;

        public string RemoveUnnecessaryCharacters(string sourceCode)
        {
            return RemoveComments(RemoveMultilineComments(sourceCode));
        }

        private static string RemoveComments(string sourceCode)
        {
            return Regex.Replace(sourceCode, @"(?is)\s\/\*.+?\\*\/\s", String.Empty);
        }

        private static string RemoveMultilineComments(string sourceCode)
        {
            return Regex.Replace(sourceCode, @"\s\/\/.+", String.Empty);
        }
        //File open function
        public void OpenFromFile(OpenFileDialog openFileDialog, TextBox sourceCodeTextBox)
        {
            try
            {
                using (openFileDialog)
                {
                    openFileDialog.FileName = String.Empty;
                    if (openFileDialog.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    try
                    {
                        using (var fileStream = File.OpenRead(openFileDialog.FileName))
                        {
                            TextReader textReader = new StreamReader(fileStream);

                            sourceCodeTextBox.Text = this.RemoveUnnecessaryCharacters(textReader.ReadToEnd());
                            for (var lineCount = 0; lineCount < sourceCodeTextBox.Lines.Length; lineCount++)
                            {
                                var currentLine = sourceCodeTextBox.Lines[lineCount];
                                var nextLine = sourceCodeTextBox.Lines[lineCount + 1];
                                if ((String.IsNullOrEmpty(currentLine) || String.IsNullOrWhiteSpace(currentLine))
                                    && (String.IsNullOrEmpty(nextLine) || String.IsNullOrWhiteSpace(nextLine)))
                                {
                                    this._sourceCode = Environment.NewLine;
                                }
                                else
                                {
                                    this._sourceCode += currentLine + Environment.NewLine;
                                }
                            }

                            sourceCodeTextBox.Text = this._sourceCode;

                            textReader.Close();
                            fileStream.Close();
                        }
                    }
                    catch (Exception) { }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        //Save file dialog
        public static void SaveToFile(SaveFileDialog saveFileDialog, TextBox sourceCodeTextBox)
        {
            try
            {
                saveFileDialog.FileName = String.Empty;
                using (saveFileDialog)
                {
                    if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    try
                    {
                        using (var fileStream = File.Create(saveFileDialog.FileName))
                        {
                            TextWriter textWriter = new StreamWriter(fileStream);

                            textWriter.Write(sourceCodeTextBox.Text);

                            textWriter.Close();
                            fileStream.Close();
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
