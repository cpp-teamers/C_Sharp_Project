using System;
using System.Collections.Generic;
using System.Text;
using Library1;
using LibraryDialog;

namespace ManagerModule
{
    class ManagerManager
    {
        public void DisplayNotDistributedOrders(ManagerDataManager dataManager)
        {
            SortedList<string, Order> orders = dataManager.GetNotDistributedOrders();

            if (orders.Count == 0)
            {
                Console.WriteLine(" All orders distributed to RepairMen");  // Exception
                Console.WriteLine("\n Press any key");
                Console.ReadKey();
            }
            else
            {
                for (int i = 0; i < orders.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {orders.Values[i]}");
                }
                Console.WriteLine("\n Press any key");
                Console.ReadKey();
            }
        }

        public void DistributeOrders(ManagerDataManager dataManager, ManagerDialog dialog)
        {
            SortedList<string, Order> orders = dataManager.GetNotDistributedOrders();
            SortedList<string, RepairMan> repairs = dataManager.GetRepairsMan();
            if (orders.Count == 0)
            {
                Console.WriteLine(" All orders distributed to RepairMen");  
            } // Exception
            else
            {
                bool ring = true;  // Переменная для Циклического перезапуска, если менеджер дибил и не умеет читать цифры
                bool ring2 = true; // Такая же переменная
                Order order = null;
                int num; // Переменная для параметра пользователя
                int num1;
                RepairMan repair = null;
                do
                {
                    Console.Clear();
                    Console.WriteLine("               ORDERS");
                    Console.WriteLine("==========================================");
                    for (int i = 0; i < orders.Count; i++)  // Вывод нераспределенных заказов
                    {
                        Console.WriteLine($"{i + 1}. {orders.Values[i]}");
                    }
                    Console.WriteLine($"{orders.Count+1}. Back");  // Если менеджер хочет вернуться на Шаг назад по менюшке
                    Console.WriteLine("==========================================");
                    num = dialog.ChoosenOrders(); // Считавение номера выбора менеджера
                    if(orders.Count+1 == num)  
                    {
                        ring = false;
                    } // Выход из метода!!
                    else if (num > orders.Count || num <= 0)
                    {
                        Console.WriteLine(" !!You choose unexcited orders!!");
                    } // Exception
                    else
                    {
                        order = orders.Values[num - 1];
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("\nChoosen Order");
                            Console.WriteLine("==========================================");
                            Console.WriteLine(order);
                            Console.WriteLine("==========================================");
                            Console.WriteLine("               REPAIRS");
                            Console.WriteLine("==========================================");
                            for (int i = 0; i < repairs.Count; i++)
                            {
                                Console.Write($"{i + 1}. ");
                                repairs.Values[i].DisplayRepairMan();
                            }
                            Console.WriteLine($"{repairs.Count+1}. Back");
                            Console.WriteLine("==========================================");
                            num1 = dialog.ChoosenRepairs();
                            if (repairs.Count+1 == num1) // Выход из вложенного цикла!!
                            {
                                ring2 = false;
                            }
                            else if (num1 > repairs.Count || num1 <= 0)
                            {
                                Console.WriteLine(" !!You choose unexcited repairMen!!"); // Exception
                            }
                            else
                            {
                                repair = repairs.Values[num1 - 1];
                                order.Actual = false;
                                string pathOrder = orders.Keys[num - 1];
                                string pathRepair = repairs.Keys[num1 - 1];
                                repair.PathsOfOrders.Add(pathOrder);
                                dataManager.SaveOrder(order, pathOrder);
                                dataManager.SaveRepairMan(repair, pathRepair);
                                Console.WriteLine(" Order distributed to RepairMen");
                                Console.WriteLine("\n Press any key");
                                Console.ReadKey();
                                ring2 = false;
                                ring = false;
                            }
                        } while (ring2);
                    }
                } while (ring);
            }
        }
    }
}
