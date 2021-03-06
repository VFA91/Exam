﻿using System;
using System.Reflection;

namespace RefactoringGeometricalShapes
{
    class Program
    {
        /// <summary>
        /// Entry point of the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string[] nUnitArgs = { Assembly.GetExecutingAssembly().Location };

            int returnCode = NUnit.ConsoleRunner.Runner.Main(nUnitArgs);

            if (returnCode != 0)
            {
                Console.Beep();
            }
        }
    }
}
