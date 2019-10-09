﻿using System;
using System.Security.Cryptography;

namespace Cortex.SimpleSerialize.Tests
{
    public static class HashUtility
    {
        private static readonly HashAlgorithm _hashAlgorithm = SHA256.Create();

        private static readonly byte[][] _zeroHashes;

        static HashUtility()
        {
            _zeroHashes = new byte[32][];
            _zeroHashes[0] = new byte[32];
            for (var index = 1; index < 32; index++)
            {
                _zeroHashes[index] = Hash(_zeroHashes[index - 1], _zeroHashes[index - 1]);
            }
        }

        public static ReadOnlySpan<byte> Chunk(ReadOnlySpan<byte> input)
        {
            var chunk = new Span<byte>(new byte[32]);
            input.CopyTo(chunk);
            return chunk;
        }

        public static byte[] Hash(ReadOnlySpan<byte> a, ReadOnlySpan<byte> b)
        {
            var combined = new Span<byte>(new byte[64]);
            a.CopyTo(combined);
            b.CopyTo(combined.Slice(32));
            return _hashAlgorithm.ComputeHash(combined.ToArray());
        }

        public static ReadOnlySpan<byte> Merge(ReadOnlySpan<byte> a, byte[][] branch)
        {
            var result = a;
            foreach (var b in branch)
            {
                result = Hash(result, b);
            }
            return result;
        }

        public static byte[][] ZeroHashes(int start, int end)
        {
            return _zeroHashes[start..end];
        }
    }
}