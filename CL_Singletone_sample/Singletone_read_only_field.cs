using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_Singletone_sample
{
    public sealed class Singleton_readonly
    {
        private static readonly Singleton_readonly instance = new Singleton_readonly();

       // Этот вариант тоже thread-safe и основан на любопытном свойстве полей 
      //  readonly — они иницализируются не сразу, а при первом вызове.
        static Singleton_readonly()
        {
        }

        private Singleton_readonly()
        {
        }

        public static Singleton_readonly Instance
        {
            get
            {
                return instance;
            }
        }
    }

    /*
     — Если у класса есть статичные методы, то при их вызове readonly поле инициализируется автоматически.
     — Конструктор может быть только статичным. Это особенность компилятора — если конструткор не статичен, то тип будет помечен как beforefieldinit и readonly создадутся одновременно со static-ами.
     — Статичные конструкторы нескольких связанных Singleton-ов могут нечаянно зациклить друг друга, и тогда уже ничто не поможет и никто не спасёт.        
     */
}
