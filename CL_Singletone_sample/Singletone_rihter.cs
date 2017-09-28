using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CL_Singletone_sample{
    
    public sealed class Singletone_rihter
    {
        private static readonly Object s_lock = new Object();
        private static Singletone_rihter instance = null;

        private Singletone_rihter()
        {
        }

        public static Singletone_rihter Instance
        {
            get
            {
                if (instance != null) return instance;
                Monitor.Enter(s_lock);
                Singletone_rihter temp = new Singletone_rihter();
                Interlocked.Exchange(ref instance, temp);
                Monitor.Exit(s_lock);
                return instance;
            }
        }
    }
}
/*
 * 
 На последний вариант — все же если несколько потоков запросят Instance — создадутся несколько копий синглтона. 
 В ссылку instance запишется только одна из них конечно, и все потоки получат только одну, но тем не менее. 
 Если это например, логгер, который сразу должен открыть файл, или коннект к базе данных, то такой вариант неприемлем. 
 Или если класс «тяжелый», что его создание и ининциализация «дороже», чем lock, то использование интерлока просто невыгодно.
Скажем так — это приемлемо если должен «жить» только один объект, а если же должен быть «создан» только один объект, то нет. 
Вариант с lock() как раз таки гарантирует создание только одного объекта, что под синглтон больше подходит и по совместимости/переносимости в частности и по логике вообще.

     
     
     
     
     
     */
