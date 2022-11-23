// Grading ID: S7105
// Program #4
// Due date: 4/18/2021
// CIS 199-02
// This program displays 6 sets
// of repair records before and
// after modifying the data.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Program_4
{
    public class Program
    {
        static void Main(string[] args)
        {
            // creating RepairRecord objects and storing them in array

            RepairRecord[] record = new RepairRecord[6];
            for (int x = 0; x < record.Length; x++)
            record[x] = new RepairRecord();


            record[0].ZipCode = 41051;
            record[0].MakeModel = "Ford F150";
            record[0].ModelYear = 2011;
            record[0].SerialNumber = "C493768459";
            record[0].AppointmentLength = 45;
            record[0].TechnicianName = "Bob Jones";
            record[0].Warranty = false;

            record[1].ZipCode = 40203;
            record[1].MakeModel = "Toyota Matrix";
            record[1].ModelYear = 2005;
            record[1].SerialNumber = "C857395785";
            record[1].AppointmentLength = 60;
            record[1].TechnicianName = "Monica Fitzgerald";
            record[1].Warranty = true;

            record[2].ZipCode = 40202;
            record[2].MakeModel = "Tesla Model 3";
            record[2].ModelYear = 2019;
            record[2].SerialNumber = "C583953958";
            record[2].AppointmentLength = 15;
            record[2].TechnicianName = "Bob Jones";
            record[2].Warranty = false;

            record[3].ZipCode = 40208;
            record[3].MakeModel = "Mclaren F1";
            record[3].ModelYear = 2020;
            record[3].SerialNumber = "C968486749";
            record[3].AppointmentLength = 120;
            record[3].TechnicianName = "Mike Lewis";
            record[3].Warranty = true;

            record[4].ZipCode = 40212;
            record[4].MakeModel = "Gallifreyan Tardis";
            record[4].ModelYear = 2500;
            record[4].SerialNumber = "C968857575";
            record[4].AppointmentLength = 150;
            record[4].TechnicianName = "The Doctor";
            record[4].Warranty = true;

            record[5].ZipCode = 40211;
            record[5].MakeModel = "Correllian Tie Fighter";
            record[5].ModelYear = 3600;
            record[5].SerialNumber = "C565756555";
            record[5].AppointmentLength = 80;
            record[5].TechnicianName = "Luke Skywalker";
            record[5].Warranty = false;

            OutputRepairRecord(record); // display array values

            // modifications to array values

            record[0].ZipCode = 9999;
            record[1].MakeModel = "Honda Civic";
            record[2].ModelYear = 3000;
            record[3].SerialNumber = "";
            record[4].AppointmentLength = 15;
            record[5].TechnicianName = "John Smith";

            OutputRepairRecord(record); // display array values after modifying values
            ReadLine(); // to prevent program close
        }

        // define OutputRepairRecord method
        static void OutputRepairRecord (RepairRecord[] record)
        {
            // use of for loop to display methods & array values

           for (int i = 0; i < 6; i++)
            {
                WriteLine("Service Location Zip Code: {0}", record[i].ZipCode);
                WriteLine("Year: {0}", record[i].ModelYear);
                WriteLine("Make and Model: {0}", record[i].MakeModel);
                WriteLine("Serial Number: {0}", record[i].SerialNumber);
                WriteLine("Appointment Length: {0}", record[i].AppointmentLength);
                WriteLine("Appointment Hours: {0}", record[i].AppointmentHours.ToString());
                WriteLine("Technician Name: {0}", record[i].TechnicianName);
                WriteLine("Warranty Coverage?: {0}", record[i].Warranty);
                WriteLine("Calculate Cost Output: {0}", record[i].CalcCost());
                WriteLine("");
            }
        }
    }

    //define RepairRecord class
    class RepairRecord
    {
        // backing fields for properties

        private int _zipCode;
        private string _makeModel;
        private string _serialNumber;
        private int _modelYear;
        private int _appointmentLength;
        private double _appointmentHours;
        private string _technicianName;
        private bool _warranty = false;

        // const variables

        const int DEFAULT_ZIP = 40204;
        const string DEFAULT_MAKEMODEL = "Unknown Make/Model";
        const string DEFAULT_SERIAL = "A000000000";
        const int YEAR_MIN = 1886;
        const int YEAR_MAX = 9999;
        const int DEFAULT_YEAR = 2000;
        const int APPOINTMENT_MIN = 15;
        const int APPOINTMENT_MAX = 180;
        const int DEFAULT_APPOINTMENT = 30;
        const double MINUTE_CONVERSTION = 60;
        const string DEFAULT_TECHNICIAN = "John Smith";

        // constructor
        public RepairRecord ()
        {
            ZipCode = _zipCode;
            MakeModel = _makeModel;
            SerialNumber = _serialNumber;
            ModelYear = _modelYear;
            AppointmentLength = _appointmentLength;
            TechnicianName = _technicianName;
            Warranty = _warranty;
        }

        // properties
        public int ZipCode
        {
            // precondition: none
            // postcondition: zip code is returned
            get
            {
                return _zipCode;
            }

            // precondition: zipcode is between 00000 and 99999
            // postcondition: zip code has been set
            set
            {
                if (value >= 00000 && value <= 99999)
                {
                    _zipCode = value;
                }

                else
                {
                    _zipCode = DEFAULT_ZIP;
                }
            }
        }

        public string MakeModel
        {
            // precondition: none
            // postcondition: make and model string is returned
            get
            {
                return _makeModel;
            }

            // precondition: make and model string is valid and not blank
            // postcondition: make and model string is set
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _makeModel = value;
                }
                else
                {
                    _makeModel = DEFAULT_MAKEMODEL;
                }

            }
        }

        public string SerialNumber
        {
            // precondition: none
            // postcondition: serial number is returned
            get
            {
                return _serialNumber;
            }

            // precondition: serial # length is 10 & not blank
            // postcondition: serial # is set
            set
            {
                //value.Length == SERIAL_MAX &&
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _serialNumber = value;
                }
                else
                {
                    _serialNumber = DEFAULT_SERIAL;
                }
            }
        }

        public int ModelYear
        {
            // precondition: none
            // postcondition: model year is returned
            get
            {
                return _modelYear;
            }

            // precondition: year between 1886 and 9999
            // postcondition: model year is set
            set
            {
                if (value >= YEAR_MIN && value <= YEAR_MAX)
                {
                    _modelYear = value;
                }
                else
                {
                    _modelYear = DEFAULT_YEAR;
                }
            }
        }

        public int AppointmentLength
        {
            // precondition: none
            // postcondition: appointment length returned
            get
            {
                return _appointmentLength;
            }

            // precondition: has to be at least 15mins and less than 3hours (180mins)
            // postcondition: appointment length and hours set
            set
            {
                if (value >= APPOINTMENT_MIN && value <= APPOINTMENT_MAX)
                {
                    _appointmentLength = value;
                }
                else
                {
                    _appointmentLength = DEFAULT_APPOINTMENT;
                }
            }
        }

        public double AppointmentHours
        {
            // precondition: none
            // postcondtion: appointment hours returned
            get
            {
                _appointmentHours = _appointmentLength / MINUTE_CONVERSTION;
                return _appointmentHours;
            }
        }

        public string TechnicianName
        {
            // precondition: none
            // postcondition: technician name returned
            get
            {
                return _technicianName;
            }

            // precondition: is not blank
            // postcondition: technician name is set
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _technicianName = value;
                }
                else
                {
                    _technicianName = DEFAULT_TECHNICIAN;
                }
            }
        }

        public bool Warranty
        {
            // precondition: none
            // postcondition: warranty is returned
            get
            {
                return _warranty;
            }

            // precondition: value is true or false
            // postcondition: warranty is set
            set
            {
                if (value == true)
                {
                    _warranty = true;
                }
                else
                {
                    _warranty = false;
                }
            }
        }

        // ToString() method 
        public override string ToString()
        {
            // for format of appointment length
            string result;

            result = $"{AppointmentHours:F3}";

            return result;
        }

        // CalcCost method for total
        public double CalcCost()
        {
            double cost;

            if (Warranty == true)
            {
                cost = 20;
                return cost;
            }
            else
            {
                cost = 25 + 1.50 * AppointmentLength;
                return cost;
            }

        }

    }
}
