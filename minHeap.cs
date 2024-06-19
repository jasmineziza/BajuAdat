using System;

namespace ButikIndonesia
{
    public class MinHeap
    {
        private List<Baju> heap;

        public MinHeap()
        {
            heap = new List<Baju>();
        }

        public int Count
        {
            get { return heap.Count; }
        }

        public void Add(Baju item)
        {
            heap.Add(item);
            HeapifyUp(heap.Count - 1);
        }

        public Baju RemoveMin()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Heap is empty");

            Baju min = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            if (heap.Count > 1)
                HeapifyDown(0);

            return min;
        }

        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parent = (index - 1) / 2;
                if (heap[parent].Harga > heap[index].Harga)
                {
                    Swap(parent, index);
                    index = parent;
                }
                else
                {
                    break;
                }
            }
        }

        private void HeapifyDown(int index)
        {
            while (true)
            {
                int left = 2 * index + 1;
                int right = 2 * index + 2;
                int smallest = index;

                if (left < heap.Count && heap[left].Harga < heap[smallest].Harga)
                    smallest = left;
                if (right < heap.Count && heap[right].Harga < heap[smallest].Harga)
                    smallest = right;

                if (smallest != index)
                {
                    Swap(smallest, index);
                    index = smallest;
                }
                else
                {
                    break;
                }
            }
        }

        private void Swap(int i, int j)
        {
            Baju temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
    }
}