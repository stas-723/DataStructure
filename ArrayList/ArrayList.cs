using System;

namespace DataStucture.ArrayList
{
    public class ArrayList
    {
        public int Length { get; private set; }
        private int[] _array;
        private double _NumberLayuotplace = 1.33d;



        public ArrayList()
        {
            _array = new int[3];
            Length = 0;
        }
        public ArrayList(int[] array)
        {
            if(array.Length == 0)
            {
                throw new Exception("Your array is empty!");
            }
            else
            {
                _array = new int[array.Length];
                Length = array.Length;
                Array.Copy(array, _array, array.Length);
            }
        }

        public ArrayList(int i)
        {
            _array = new int[i];
            Length = 0;
        }

        public void Add(int value)
        {
            if(_array.Length <= Length)
            {
                IncremenLength();
            }
            AddItemByIndex(Length, value);
        }

        public void AddStart(int value)
        {
            if (_array.Length <= Length)
            {
                IncremenLength();
            }
            AddItemByIndex(0, value);
        }

        public int GetLength()
        {
            int count = 0;
            for(int i = 0; i < Length; i++)
            {
                count++;
            }
            return count;
        }

        public void AddItemByIndex(int index, int value)
        {
            if(_array.Length <= Length)
            {
                IncremenLength();
            }

            if(index > Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                if(index == Length)
                {
                    _array[index] = value;
                    Length++;
                }
                else
                {
                    Length++;
                    DisplacementRight(index);
                    _array[index] = value;
                }
            }
        }



        private void DisplacementRight(int index)
        {
            for (int j = Length - 1; j > index; j--)
            {
                _array[j] = _array[j - 1];
            }
            
        }

        private void DisplacementLeft(int index)
        {
            for (int j = index; j < Length - 1; j++)
            {
                _array[j] = _array[j + 1];
            }
        }

        private void IncremenLength(int num = 1)
        {
            int newLength = _array.Length;
            while (newLength <= Length + num)
            {
                newLength = (int)(newLength * _NumberLayuotplace + 1);
            }
            int[] newArray = new int[newLength];
            Array.Copy(_array, newArray, _array.Length);
            _array = newArray;
        }
    }
}
