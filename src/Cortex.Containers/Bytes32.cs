﻿using System;
using System.Collections.Generic;

namespace Cortex.Containers
{
    public class Bytes32 : IEquatable<Bytes32>
    {
        public const int Length = 32;

        private readonly byte[] _bytes;

        public Bytes32()
        {
            _bytes = new byte[Length];
        }

        public Bytes32(ReadOnlySpan<byte> span)
        {
            if (span.Length != Length)
            {
                throw new ArgumentOutOfRangeException(nameof(span), span.Length, $"{nameof(Bytes32)} must have exactly {Length} bytes");
            }
            _bytes = span.ToArray();
        }

        public static implicit operator Bytes32(byte[] bytes) => new Bytes32(bytes);

        public static implicit operator Bytes32(Span<byte> span) => new Bytes32(span);

        public static implicit operator Bytes32(ReadOnlySpan<byte> span) => new Bytes32(span);

        public static implicit operator ReadOnlySpan<byte>(Bytes32 hash) => hash.AsSpan();

        public ReadOnlySpan<byte> AsSpan()
        {
            return new ReadOnlySpan<byte>(_bytes);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Bytes32);
        }

        public bool Equals(Bytes32 other)
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