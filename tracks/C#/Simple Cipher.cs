using System;
using System.Linq;

public class SimpleCipher
{
        public string Key { get; }

        private static readonly Random _generator = new Random();

        public SimpleCipher() : this(string.Concat(Enumerable.Range(1, 100).Select(index => (char)_generator.Next(97, 122)))) { }

        public SimpleCipher(string key) => Key = key;

        public string Encode(string plaintext) => string.Concat(Enumerable.Range(0, plaintext.Length).Zip(plaintext, (i, c) => c + Key[i %Key.Length] - 97).Select(j => (char)(j <= 122 ? j : j - 26)));

        public string Decode(string ciphertext) => string.Concat(Enumerable.Range(0, ciphertext.Length).Zip(ciphertext, (i, c) => c - Key[i % Key.Length] + 97).Select(j => (char)(j >= 97 ? j : j + 26)));
}
