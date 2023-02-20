using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Linq;
using System.Net.Mime;

namespace Library
{
    public class DocumentTemplate
    {
        public char[] symbols;
        public string[] descriptions;
        public char[] delimiters;
    }

    public class Document
    {
        public string text;
        public DocumentTemplate template;
    }

    public class DocumentProcessor
    {
        public Document ApplyTemplate(DocumentTemplate template, Document document)
        {
            Logger.Log("Applying template to document", LogLevel.Info);

            StringBuilder resultText = new StringBuilder();
            int currentSymbolIndex = 0;
            foreach (char c in document.text)
            {
                if (template.symbols.Contains(c))
                {
                    int symbolIndex = Array.IndexOf(template.symbols, c);
                    resultText.Append(template.descriptions[symbolIndex]);
                    currentSymbolIndex = symbolIndex;
                }
                else if (template.delimiters.Contains(c))
                {
                    int delimiterIndex = Array.IndexOf(template.delimiters, c);
                    if (delimiterIndex == currentSymbolIndex + 1)
                    {
                        resultText.Append(c);
                    }
                }
                else
                {
                    resultText.Append(c);
                }
            }
            Document resultDocument = new Document();
            resultDocument.text = resultText.ToString();
            resultDocument.template = template;

            Logger.Log("Template applied successfully", LogLevel.Info);
            return resultDocument;
        }

        public void SaveDocument(Document document, string filePath)
        {
            Logger.Log("Saving document", LogLevel.Info);

            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc";
            Application oWord = new Application();
            Document oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            oDoc.Content.Text = document.text; 
            oDoc.Close(ref oMissing, ref oMissing, ref oMissing);
            oWord.Quit(ref oMissing, ref oMissing, ref oMissing);

            Logger.Log("Document saved successfully", LogLevel.Info);
        }
    }
}
