/*
    Example of generics in C#
*/

using System;

namespace csharp_data_structures
{
    public class GenericsExample
    {
        public static void Main(string[] args)
        {
            GenericArray<int> newGenericArray = new GenericArray<int>(5);
            
            for (int i = 0; i < newGenericArray.Size(); i++) {
                newGenericArray.SetItem(i, i);
            }

            newGenericArray.Print();
        }
    }

    /*
        The 'GenericArray' class we made using generics in C#
    */
    public class GenericArray<T> {
        private T[] array;

        public GenericArray(int initialSize) {
            if (initialSize <= 0)
                throw new System.ArgumentException("Parameter must be greater than 0.", "initialSize");
            
            array = new T[initialSize];
        }

        public T GetItem(int index) {
            return array[index];
        }

        public void SetItem(int index, T value) {
            array[index] = value;
        }

        public int Size() {
            return array.Length;
        }

        public void Print() {
            for (int i = 0; i < Size(); i++) {
                if (i != Size() - 1)
                    Console.Write(GetItem(i) + " ");
                else
                    Console.Write(GetItem(i));
            }
        }
    }
}