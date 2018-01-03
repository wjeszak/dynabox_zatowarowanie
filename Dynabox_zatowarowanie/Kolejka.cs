using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynabox_zatowarowanie
{
    public class Kolejka
    {
        private int head, tail;
        private short[] elements = new short[16];
        private int len = 15;
        public Kolejka()
        {
            head = 0;
            tail = 0;
        }

        public void Add(short el)
        {
            int tmp_head;
            tmp_head = (head + 1) & len;
            if (tmp_head == tail)
            {
                // nadpisanie kolejki
            }
            else
                head = tmp_head;
            elements[tmp_head] = el;
        }

        public short Get()
        {
            if(head != tail)
            {
                // coś jest w kolejce
                tail = (tail + 1) & len;
                return elements[tail];
            }
            // pusta
            return 0xFF;
        }

        public int GetNumberOfElements()
        {
            return (head - tail) & len;
        }

        public short[] Display()
        {
            return elements;
        }
    }
}
