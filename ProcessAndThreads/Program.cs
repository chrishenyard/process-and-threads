using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ProcessAndThreads {
    class Program {
        static void Main(string[] args) {
            var tasks = new List<Task>();
            Process process = Process.GetCurrentProcess();

            for (int i = 0; i < 2; i++) {
                var threadCount = i + 1;
                tasks.Add(Task.Factory.StartNew(() => {
                    Console.WriteLine(string.Format("Thread number {0} in ProcessID {1}", threadCount, process.Id));
                }));
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
