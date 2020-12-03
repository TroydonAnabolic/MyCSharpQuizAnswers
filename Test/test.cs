//using Microsoft.Office.Interop.Word;
//using OfficeOpenXml;
//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Data;
//using System.IO;
//using System.Linq;


//namespace ConsoleApp6
//{
//    class Program
//    {


//        static void Main(string[] args)
//        {
//            bool carryOn = true;

//            // TO DO: Create a loop where we can revert back to main menu once excel writing is done so we can begin word and pdf search and find
//            // Console.WriteLine("Select 'excel' to add xlsx and csv, select 'word for word search, or 'pdf' for pdf search, or q to quit");
//            Console.WriteLine("The program is now scanning and copying PPI info from selected files");
//            CopyTablesExcel();
//            Console.WriteLine("Worksheet Created, Hit any key to exit");


//            //while (carryOn)
//            //{
//            //    string command = Console.ReadLine();



//            //    if (command == "q") carryOn = false;
//            //    // Run the Method
//            //    if (command == "excel")
//            //    {
//            //        CopyTablesExcel();
//            //        Console.WriteLine("Worksheet Created");
//            //        break;
//            //    }
//            //    else if (command == "word")
//            //    {
//            //        //searchMsWord();
//            //        break;
//            //    }
//            //}
//            Console.ReadKey();

//        }

//        public static System.Data.DataTable CSVToDT(string[] csvRows)
//        {
//            // create a data table
//            System.Data.DataTable dt = new System.Data.DataTable();

//            // break first row into an array of strings
//            string[] headers = csvRows[0].Split(',');

//            // add each header into the first row
//            foreach (string header in headers)
//            {
//                dt.Columns.Add(header);
//            }

//            // based on amount of rows in the excel sheet
//            for (int i = 1; i < csvRows.Length; i++)
//            {
//                // creates a row vairable
//                DataRow dr = dt.NewRow();

//                // Splits all the rows in datable 
//                string[] row = csvRows[i].Split(',');
//                for (int j = 0; j < row.Length; j++)
//                {
//                    dr[j] = row[j];
//                }
//                dt.Rows.Add(dr);
//            }
//            return dt;
//        }

//        public static void CopyTablesExcel()
//        {
//            // First we are going to read all the files and data and assign them into variables

//            // Opening and reading existing Excel xlsx file
//            FileInfo fi = new FileInfo(@"M:/troyi/Documents/Troydon/IT_Projects/Personally Identifiable Information (PII)/Assets/spreadsheet1.xlsx");
//            ExcelPackage excelPackage = new ExcelPackage(fi);
//            {
//                //So it doesn't throw an exception if worksheet not found, but return null in case it doesn't find it
//                ExcelWorksheet spreadSheet1 = excelPackage.Workbook.Worksheets.FirstOrDefault(x => x.Name == "spreadsheet1");

//                // Read CSV
//                var rows = File.ReadAllLines(@"M:/troyi/Documents/Troydon/IT_Projects/Personally Identifiable Information (PII)/Assets/csv2.csv");

//                //Read CSV as DataTable, that accepts rows
//                System.Data.DataTable csvDataTable = CSVToDT(rows);
//                //Filter the data
//                DataView csvDataView = csvDataTable.DefaultView;
//                //csvDataView.RowFilter = "Gender = 'Mr' or Gender = 'Ms'";
//                //dv.RowFilter = "Address Line 2 == null";
//                csvDataTable = csvDataView.ToTable();


//                FileInfo outputFI = new FileInfo(@"M:\troyi\Documents\Troydon\IT_Projects\Personally Identifiable Information (PII)\Assets\\File.xlsx");
//                //Create a new ExcelPackage and write retrieved data onto it
//                ExcelPackage excelPackage2 = new ExcelPackage(outputFI);

//                //Set some properties of the Excel document
//                excelPackage2.Workbook.Properties.Author = "Troydon Luicien";
//                excelPackage2.Workbook.Properties.Title = "Personally Identifiable Information(PPI)";
//                excelPackage2.Workbook.Properties.Subject = "PPI results";
//                excelPackage2.Workbook.Properties.Created = DateTime.Now;

//                //directly copy the original XLSX sheet
//                var worksheet = excelPackage2.Workbook.Worksheets.Add("PP1 Sheet1", spreadSheet1);

      

//                //Load data from DataTable
//                //Bear in mind that the excel is 1-base while the datatable is 0-base
//                int startRow = worksheet.Dimension.End.Row + 1;
//                int startColumn = 1;
//                // copies all data table data onto table beginning from the data table cell
//                worksheet.Cells[startRow, startColumn].LoadFromDataTable(csvDataTable, false);

//                // add more headers with gross and total tax cels
//                worksheet.Cells[1, 21].Value = "TOTAL TAX WITHELD";
//                worksheet.Cells[1, 22].Value = "Gross Payments";

//                // Load data from microsoft word
//                // make family name list and given name list and use it as a condition for searching and a header too
//                List<string> headerList = new List<string>();
//                //gather column header names
//                // copy all the heading data from
//                for (int j = 1; j <= spreadSheet1.Dimension.End.Column; j++)
//                {
//                    // add the headers to the list so we can use for search and print to console to test
//                    headerList.Add(worksheet.Cells[1, j].Value.ToString());
//                    //  Console.WriteLine(spreadSheet1.Cells[1, j].Value);
//                }

//                // after test try changing i to start from worksheet.Dimension.Start.Row + 1
//                // for each row we add one of the list items
//                int currRow = worksheet.Dimension.End.Row + 1, counter = 0; // start from the first empty as current row
//                // assign position to find where to insert value of column in spreadsheet
//                int familyName = headerList.IndexOf("Family Name") + 1, // specify index in front by +1 because of base 1
//                    givenName = headerList.IndexOf("Given Name") + 1,
//                    addressLine1 = headerList.IndexOf("Address Line 1") + 1,
//                    suburb = headerList.IndexOf("Suburb") + 1,
//                    state = headerList.IndexOf("State") + 1,
//                    postCode = headerList.IndexOf("Post Code") + 1,
//                    taxFileNumber = headerList.IndexOf("Tax File Number") + 1,
//                    totalTaxW = headerList.IndexOf("TOTAL TAX WITHELD") + 1,
//                    grossPayments = headerList.IndexOf("Gross Payments") + 1;

//                // we know the number of results is the total number of retrieved results in the list / 9 as there are 9 fields we are looking for
//                int numberOfResults = searchMsWord().Count() / 8;

//                for (int j = 0; j < numberOfResults; j++)
//                {
                  
//                    // assign current row with the current i instance, with the instance value of the list on position i
//                    worksheet.Cells[currRow, familyName].Value = searchMsWord()[counter];
//                    counter++;
//                    worksheet.Cells[currRow, givenName].Value = searchMsWord()[counter];
//                    counter++;
//                    worksheet.Cells[currRow, addressLine1].Value = searchMsWord()[counter];
//                    counter++;
//                    worksheet.Cells[currRow, suburb].Value = searchMsWord()[counter];
//                    counter++;
//                    worksheet.Cells[currRow, state].Value = searchMsWord()[counter];
//                    counter++;
//                    worksheet.Cells[currRow, postCode].Value = searchMsWord()[counter];// out of bounds error occurs
//                    counter++;
//                    worksheet.Cells[currRow, taxFileNumber].Value = searchMsWord()[counter];
//                    counter++;
//                    worksheet.Cells[currRow, 21].Value = searchMsWord()[counter];
//                    counter++;
//                    worksheet.Cells[currRow, 22].Value = searchMsWord()[counter];
//                    counter++;

//                    // go to the next row
//                    currRow++;

//                }


//                // Load from MS Word
//                // Console.WriteLine(searchMsWord());          

//                //Save the ExcelPackage
//                excelPackage2.Save();
//                excelPackage.Dispose();
//            }
//        }

//        public static List<string> searchMsWord()
//        {
//            // Create new word application
//            Application word = new Application();

//            // says it can have missing value
//            object miss = System.Reflection.Missing.Value;
//            object path = @"M:\\troyi\\Documents/Troydon/IT_Projects/Personally Identifiable Information (PII)/Assets/word1.docx";
//            object readOnly = true;
//            Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
//            string totaltext = "";

//            // Create range to use as search PDF variable
//            Range rangeFamilyName = docs.Content;
//            rangeFamilyName.Find.Text = "tax withheld box you must lodge a tax return. If no tax";

//            // add adds a mew [paragraph after reaching the end and assigns everything to totalText
//            for (int i = 0; i < docs.Paragraphs.Count; i++)
//            {
//                totaltext += "\r\n" + docs.Paragraphs[i + 1].Range.Text.ToString();
//            }

//            // Splits on each line break to create an array of rows
//            string[] rows = totaltext.Split(new[] {Environment.NewLine}, StringSplitOptions.None);

//            // Create variables to hold the results retrieved
//            List<string> msWordPpiFoundList = new List<string>();
//            int msWordNumberOfRecords = 0;

//            // search each rows for results
//            for (int i = 0; i < rows.Length; i++)
//            {
//                // when we find a match we add it to the list of valuable PPI data
//                // TODO: which can later be added to the table using the search table method found earlier, and then iterate through list, if list.contains(header item) {add header}
//                if (rows[i].Contains(rangeFamilyName.Find.Text))
//                {
//                    // assigns full name to the found results(which is i + 1 as in the line under found value)
//                    // then break into an array so we can seperate family and given name
//                    string[] fullName = rows[i + 3].Split(new char[] {' '}, StringSplitOptions.None);
//                    string familyName = "", givenName = ""; // TO DO: debug here to 
//                    familyName = fullName[0];
//                    givenName = fullName[1];
//                    // now add the family and given name
//                    msWordPpiFoundList.Add(familyName);
//                    msWordPpiFoundList.Add(givenName);
//                    msWordPpiFoundList.Add(rows[i + 7]);// address line 1

//                    // spli this row into strings array as it has suburb and postcode
//                    string[] addressLine2 = rows[i + 11].Split(new char[] { ' ' }, StringSplitOptions.None);
//                    bool suburbOnly = false;
//                    for (int j = 0; j < addressLine2.Length; j++)
//                    {
//                        // reassigns the postcodeOnly
//                        suburbOnly = (addressLine2[j] != "NSW" && addressLine2[j] != "QLD" && addressLine2[j] != "VIC" && addressLine2[j] != "ACT" && addressLine2[j] != "NT"
//                            && addressLine2[j] != "ACT" && addressLine2[j] != "WA" && addressLine2[j] != "TAS" && addressLine2[j] != "SA"
//                            && !addressLine2[j].Any(char.IsDigit));

//                        // If the words does not include any state or number then we add it
//                        if (suburbOnly) 
//                        {
//                            // if the suburb is more than one word, we add j and cocatenate the word in front so long as it is not a state
//                            if (addressLine2.Length > 3 && addressLine2[j + 1] != "NSW" && addressLine2[j + 1] != "QLD" && addressLine2[j + 1] != "VIC" && addressLine2[j + 1] != "ACT"
//                                && addressLine2[j] != "NT"
//                            && addressLine2[j + 1] != "ACT" && addressLine2[j + 1] != "WA" && addressLine2[j + 1] != "TAS" && addressLine2[j + 1] != "SA") 
//                            {
//                                msWordPpiFoundList.Add(addressLine2[j] + " " + addressLine2[j + 1]);
//                               // msWordPpiFoundList.Add(addressLine2[0]);
//                            }
//                            else if (addressLine2.Length == 3) msWordPpiFoundList.Add(addressLine2[j]); // if the suburb is only one word, then length of column has to be 3, so we just add it(given it meets suburbOnly bool)

//                        }
//                        // if it fails to meet suburb only condition then we know it is a state, so we add it as the next list item
//                        //the postcode will automatically get the value of the next list item
//                        if (!suburbOnly) msWordPpiFoundList.Add(addressLine2[j]);
//                    }

//                    msWordPpiFoundList.Add(rows[i + 66]); // tax file number
//                    msWordPpiFoundList.Add(rows[i + 70]); // tax witheld
//                    msWordPpiFoundList.Add(rows[i + 100]); // gross

//                    msWordNumberOfRecords++; 
//                }
//            }

//            //msWordPpiFoundList.ForEach(Console.WriteLine);


//            FileInfo outputFI = new FileInfo(@"M:\troyi\Documents\Troydon\IT_Projects\Personally Identifiable Information (PII)\Assets\\File.xlsx");

//            docs.Close();
//            word.Quit();

//            //string combindedString = string.Join(Environment.NewLine, msWordPpiFoundList.ToArray());

//            return msWordPpiFoundList;

//        }
//    }
//}

