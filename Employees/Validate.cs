using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Employees
{
    /// <summary>
    /// Validate class that validates input rows
    /// </summary>
    public static class Validate
    {
        /// <summary>
        /// Validate input row
        /// </summary>
        /// <param name="line">actual row</param>
        /// <param name="projectId">returns the projectId from that row</param>
        public static Employee? ValidateRow(string line, out int projectId)
        {
            projectId = 0;
            //Split the row into words
            string[] data = line.Split(",");
            //Check the lenght to have atleast needed amount of word
            if (data.Length >= 4)
            {
                //Try to take the project ID
                if (int.TryParse(data[1].Trim(), out projectId))
                {
                    //Try to take Employee ID
                    if (int.TryParse(data[0].Trim(), out int employeeId))
                    {
                        string dateString = data[2].Trim();
                        //Get the DateTime value from string if possible
                        if (GetDateTimeFromString(dateString) is DateTime startDate)
                        {
                            dateString = data[3].Trim();
                            DateTime endDate = DateTime.Now;
                            //Check if string is NULL to set it as - NOW
                            if (!dateString.ToLower().Equals("null"))
                            {
                                //Get the DateTime value from string if possible
                                if (GetDateTimeFromString(dateString) is DateTime dateTo)
                                {
                                    endDate = dateTo;
                                }
                                else
                                {
                                    //Return if Date is not a valid string
                                    return null;
                                }
                            }
                            //If all parts of the row are valid return the new Employee item
                            return new(employeeId, startDate, endDate);
                        }
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// Get date from a string
        /// </summary>
        /// <param name="dateString">dateTime string input</param>
        /// <returns>Converted value as DateTime or null if not possible</returns>
        public static DateTime? GetDateTimeFromString(string dateString)
        {
            if (Regex.Matches(dateString.Trim(), "[^a-zA-Z0-9]") is MatchCollection matches)
            {
                if (matches.Count > 1)
                {
                    string separatorOne = matches[0].Value;
                    string separatorTwo = matches[1].Value;
                    string[] formats = {
                                        $"dd{separatorOne}MM{separatorTwo}yyyy",
                                        $"yyyy{separatorOne}MM{separatorTwo}dd",
                                        $"MM{separatorOne}dd{separatorTwo}yyyy",
                                        $"yyyy{separatorOne}dd{separatorTwo}MM",
                                        //Can be added more...
                                        //Or we can make this as property/textbox to be inputed
                                       };
                    if (DateTime.TryParseExact(dateString, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                    {
                        return result;
                    }
                }
            }
            return null;
        }
    }
}
