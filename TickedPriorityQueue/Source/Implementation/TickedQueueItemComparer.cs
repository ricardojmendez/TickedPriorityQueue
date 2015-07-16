using System;
using System.Collections.Generic;
namespace TickedPriorityQueue
{
	/// <summary>
	/// Priority comparer for <see cref="TickedPriorityQueue.TickedQueueItem"/>.
	/// Only used internally.
	/// </summary>
	internal sealed class TickedQueueItemComparer : IComparer<TickedQueueItem>
	{
		/// <summary>
		/// <see cref="System.Collections.Generic.IComparer{TickedQueueItem}"/> implementation for sorting <see cref="TickedPriorityQueue.TickedQueueItem"/> instances by Priority, then TickLength for equal priorities.
		/// </summary>
		/// <param name='a'>
		/// First item.
		/// </param>
		/// <param name='b'>
		/// Second Item.
		/// </param>
		public int Compare(TickedQueueItem a, TickedQueueItem b)
		{
			return DefaultCompare(a,b);
		}
		
		/// <summary>
		/// <see cref="System.Collections.Generic.IComparer{TickedQueueItem}"/> implementation for sorting <see cref="TickedPriorityQueue.TickedQueueItem"/> instances by Priority, then TickLength for equal priorities.
		/// </summary>
		/// <param name='a'>
		/// First item.
		/// </param>
		/// <param name='b'>
		/// Second Item.
		/// </param>
		/// <remarks>
        /// For items with equal times and priorities, the creation id is used, so items created second will always come after
        /// those created first.
        /// </remarks>
		public static int DefaultCompare(TickedQueueItem a, TickedQueueItem b)
		{
		    var result = a.Priority.CompareTo(b.Priority);
            if (result == 0)
			{
                result = a.NextTickTime.CompareTo(b.NextTickTime);
                if (result == 0) {
                    result = a.CreationId.CompareTo(b.CreationId);
                }
            }
		    return result;
		}
	}
}

