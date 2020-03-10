namespace NetEasy
{
    /// <summary>Represents the sender or recipient of a net message.</summary>
    public struct Node
    {
        /// <summary>For a client, the client index; for the server, <see langword="null"/>.</summary>
        public byte? ClientIndex { get; }

        /// <summary>For a client, the client index; for the server, <c>256</c>.</summary>
        public int WhoAmI => ClientIndex ?? 256;

        /// <summary>
        /// Creates a new <see cref="Node"/> object representing the specified client.
        /// </summary>
        /// <param name="clientIndex">The client's index.</param>
        public Node(byte clientIndex)
        {
            ClientIndex = clientIndex;
        }

        /// <summary>
        /// Creates a new <see cref="Node"/> object representing the specified client OR server.
        /// </summary>
        /// <param name="whoAmI">The sender's whoAmI.</param>
        public Node(int whoAmI)
        {
            if (whoAmI >= 0 && whoAmI <= byte.MaxValue)
            {
                ClientIndex = (byte)whoAmI;
            }
            else
            {
                ClientIndex = null;
            }
        }

        /// <summary>Creates a new <see cref="Node"/> object representing the server.</summary>
        public static Node FromServer() => new Node();

        /// <summary>Creates a new <see cref="Node"/> object representing the specified client.</summary>
        public static Node FromClient(byte clientIndex) => new Node(clientIndex);

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Node sender) return ClientIndex == sender.ClientIndex;
            if (obj is byte b) return ClientIndex == b;
            if (obj is null) return ClientIndex == null;
            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return ClientIndex.GetHashCode();
        }

        /// <inheritdoc/>
        public static bool operator ==(Node left, Node right)
        {
            return left.Equals(right);
        }

        /// <inheritdoc/>
        public static bool operator !=(Node left, Node right)
        {
            return !(left == right);
        }
    }
}
