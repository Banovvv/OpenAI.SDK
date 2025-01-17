﻿namespace OpenAI.SDK.Chat.Models
{
    public class ChatMessageRole
    {
        private ChatMessageRole(string role)
        {
            Role = role;
        }

        private string Role { get; }

        /// <summary>
		/// The system message helps set the behavior of the assistant. 
		/// </summary>
		public static ChatMessageRole System { get; } = new ChatMessageRole("system");

        /// <summary>
        /// The user messages help instruct the assistant. They can be generated by the end users of an application, or set by a developer as an instruction.
        /// </summary>
        public static ChatMessageRole User { get; } = new ChatMessageRole("user");

        /// <summary>
        /// The assistant messages help store prior responses. They can also be written by a developer to help give examples of desired behavior.
        /// </summary>
        public static ChatMessageRole Assistant { get; } = new ChatMessageRole("assistant");

        /// <summary>
		/// Gets the string value for this role
		/// </summary>
		/// <returns>The string representation of the role</returns>
        public override string ToString()
        {
            return Role;
        }
    }
}
