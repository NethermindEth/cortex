﻿using System;
using System.Collections.Generic;

namespace Cortex.Containers
{
    public class BlsSignature : IEquatable<BlsSignature>
    {
        public const int Length = 96;

        private readonly byte[] _bytes;

        public BlsSignature()
        {
            _bytes = new byte[Length];
        }

        public BlsSignature(ReadOnlySpan<byte> span)
        {
            if (span.Length != Length)
            {
                throw new ArgumentOutOfRangeException(nameof(span), span.Length, $"{nameof(BlsSignature)} must have exactly {Length} bytes");
            }
            _bytes = span.ToArray();
        }

        public static implicit operator BlsSignature(byte[] bytes) => new BlsSignature(bytes);

        public static implicit operator BlsSignature(Span<byte> span) => new BlsSignature(span);

        public static implicit operator BlsSignature(ReadOnlySpan<byte> span) => new BlsSignature(span);

        public static implicit operator ReadOnlySpan<byte>(BlsSignature blsSignature) => blsSignature.AsSpan();

        public ReadOnlySpan<byte> AsSpan()
        {
            return new ReadOnlySpan<byte>(_bytes);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as BlsSignature);
        }

        public bool Equals(BlsSignature other)
        {
            return other != null &&
                   EqualityComparer<byte[]>.Default.Equals(_bytes, other._bytes);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_bytes);
        }

        public override string ToString()
        {
            return BitConverter.ToString(_bytes).Replace("-", "");
        }
    }
}