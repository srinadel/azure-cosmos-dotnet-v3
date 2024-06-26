﻿// ------------------------------------------------------------
// The code in this repository code was written by Lee Campbell, as a
// derived work from the original Java by Gil Tene of Azul Systems and
// Michael Barker, and released to the public domain, as explained
// at http://creativecommons.org/publicdomain/zero/1.0/
// ------------------------------------------------------------

// This file isn't generated, but this comment is necessary to exclude it from StyleCop analysis.
// <auto-generated/>

/*
 * This is a .NET port of the original Java version, which was written by
 * Gil Tene as described in
 * https://github.com/HdrHistogram/HdrHistogram
 * and released to the public domain, as explained at
 * http://creativecommons.org/publicdomain/zero/1.0/
 */

namespace HdrHistogram.Iteration
{
    /// <summary>
    /// An enumerator that enumerate over all non-zero values.
    /// </summary>
    internal sealed class RecordedValuesEnumerator : AbstractHistogramEnumerator
    {
        private int _visitedSubBucketIndex;
        private int _visitedBucketIndex;

        /// <summary>
        /// The constructor for <see cref="RecordedValuesEnumerator"/>
        /// </summary>
        /// <param name="histogram">The histogram this iterator will operate on</param>
        public RecordedValuesEnumerator(HistogramBase histogram) :base(histogram)
        {
            _visitedSubBucketIndex = -1;
            _visitedBucketIndex = -1;
        }

        protected override void IncrementIterationLevel()
        {
            _visitedSubBucketIndex = CurrentSubBucketIndex;
            _visitedBucketIndex = CurrentBucketIndex;
        }

        protected override bool ReachedIterationLevel()
        {
            long currentIndexCount = SourceHistogram.GetCountAt(CurrentBucketIndex, CurrentSubBucketIndex);
            return (currentIndexCount != 0) 
                && (
                        (_visitedSubBucketIndex != CurrentSubBucketIndex) 
                        || (_visitedBucketIndex != CurrentBucketIndex
                ));
        }
    }
}
