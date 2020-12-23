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
            SortedList<Order, string> orders = dataManager.GetNotDistributedOrders();

            if (orders.Count == 0)
            {
                Console.WriteLine(" All orders distributed to RepairMen");  // Exception
            }
            else
            {
                for (int i = 0; i < orders.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {orders.Keys[i]}");
                }
                Console.ReadKey();
            }
        }

        public void DistributeOrders(ManagerDataManager dataManager, ManagerDialog dialog)
        {
            SortedList<Order, string> orders = dataManager.GetNotDistributedOrders();
            SortedList<RepairMan, string> repairs = dataManager.GetRepairsMan();
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
                RepairMan repair = null;
                do
                {
                    Console.Clear();
                    Console.WriteLine("               ORDERS");
                    Console.WriteLine("==========================================");
                    for (int i = 0; i < orders.Count; i++)  // Вывод нераспределенных заказов
                    {
                        Console.WriteLine($"{i + 1}. {orders.Keys[i]}");
                    }
                    Console.WriteLine($"{orders.Count}. Back");  // Если менеджер хочет вернуться на Шаг назад по менюшке
                    Console.WriteLine("==========================================");
                    num = dialog.ChoosenOrders(); // Считавение номера выбора менеджера
                    if(orders.Count == num)  
                    {
                        ring = false;
                    } // Выход из метода!!
                    else if (num > orders.Count || num <= 0)
                    {
                        Console.WriteLine(" !!You choose unexcited orders!!");
                    } // Exception
                    else
                    {
                        order = orders.Keys[num - 1];
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
                                repairs.Keys[i].DisplayRepairMan();
                            }
                            Console.WriteLine($"{repairs.Count}. Back");
                            Console.WriteLine("==========================================");
                            num = dialog.ChoosenRepairs();
                            if (repairs.Count == num) // Выход из вложенного цикла!!
                            {
                                ring2 = false;
                            }
                            else if (num > repairs.Count || num <= 0)
                            {
                                Console.WriteLine(" !!You choose unexcited repairMen!!"); // Exception
                            }
                            else
                            {
                                repair = repairs.Keys[num - 1];
                                order.Actual = false;
                                repair.PathsOfOrders.Add(orders[order]);
                                dataManager.SaveOrder(order, orders[order]);
                                dataManager.SaveRepairMan(repair, repairs[repair]);
                                Console.WriteLine(" Order distributed to RepairMen");
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
