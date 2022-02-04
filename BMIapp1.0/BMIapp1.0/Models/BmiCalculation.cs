using System;
using System.Collections.Generic;
using System.Text;

namespace BMIapp1._0.Models
{
    internal class BmiCalculation
    {
        private static int previousID = 0;

        private double _height;
        private double _weight;
        private int _id;
        private DateTime creationDateTime;

        public BmiCalculation(double height, double weight)
        {
            _id = ++previousID;
            creationDateTime = DateTime.Now;
            _height = height;
            _weight = weight;
        }

        /// <summary>
        /// Height to be used in BMI calculation
        /// </summary>
        public double Height
        {
            get => _height;
            set
            {
                if (value != _height)
                {
                    _height = value;
                }
            }
        }

        /// <summary>
        /// Weight to be used in BMI calculation
        /// </summary>
        public double Weight
        {
            get => _weight;
            set
            {
                if (value != _weight)
                {
                    _weight = value;
                }
            }
        }

        /// <summary>
        /// Unique id for the BMI calculation
        /// </summary>
        public int ID { get => _id; }
        
        /// <summary>
        /// Datetime of when the BMI calculation was made
        /// </summary>
        public DateTime CreationDateTime { get => creationDateTime; }

        /// <summary>
        /// Calculated Property for BMI based on Height and Weight properties
        /// </summary>
        public double BMI
        {
            get => Math.Round(Weight / (Height / 100 * Height / 100),2);
        }

        /// <summary>
        /// Gives string representation of BMI Calculation
        /// </summary>
        /// <returns>String containing BMI Value and its date</returns>
        public override string ToString()
        {
            return $"{BMI} - {CreationDateTime.Date.ToLongDateString()}";
        }
    }
}
