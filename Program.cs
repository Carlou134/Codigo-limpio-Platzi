﻿using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; }

        static void Main(string[] args)
        {
            TaskList = new List<string>();
            int menuSelected = 0;
            do
            {
                menuSelected = ShowMainMenu();
                if ((Menu)menuSelected == Menu.Add)
                {
                    ShowMenuAdd();
                }
                else if ((Menu)menuSelected == Menu.Remove)
                {
                    ShowMenuRemove();
                }
                else if ((Menu)menuSelected == Menu.List)
                {
                    ShowMenuTaskList();
                }
            } while ((Menu)menuSelected != Menu.Exit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. TaskList pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string menuSelected = Console.ReadLine();
            return Convert.ToInt32(menuSelected);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                ShowTaskList();

                string taskNumberToDelete = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(taskNumberToDelete) - 1;

                if(indexToRemove > (TaskList.Count - 1) || indexToRemove < 0)
                    Console.WriteLine("Numero de tarea seleccionada no es válida");
                else
                {
                    if (indexToRemove > -1 && TaskList.Count > 0)
                    {
                        string taskToRemove = TaskList[indexToRemove];
                        TaskList.RemoveAt(indexToRemove);
                        Console.WriteLine("Tarea " + taskToRemove + " eliminada");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error al eliminar la tarea");
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string taskName = Console.ReadLine()!.Trim();
                if(String.IsNullOrEmpty(taskName) || String.IsNullOrWhiteSpace(taskName))
                    Console.WriteLine("Debe ingresar un nombre válido");
                else
                {
                    TaskList.Add(taskName);
                    Console.WriteLine("Tarea registrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error al añadir la tarea");
            }
        }

        public static void ShowMenuTaskList()
        {
            if (TaskList == null || TaskList.Count == 0)
            {
                Console.WriteLine("No hay TaskList por realizar");
            } 
            else
            {
                ShowTaskList();
            }
        }
    
        public static void ShowTaskList()
        {
            Console.WriteLine("----------------------------------------");
            var indexTask = 0;
            TaskList.ForEach(p => Console.WriteLine(++indexTask + ". " + p));
            Console.WriteLine("----------------------------------------");
        }
    }

    public enum Menu
    {
        Add = 1,
        Remove = 2,
        List = 3,
        Exit = 4
    } 
}
