/**
 * Type definitions for Photino.NET JavaScript interop.
 * This file provides IntelliSense for the `window.external` object injected by Photino.
 */

interface External {
    /**
     * Sends a string message to the C# backend.
     * Triggers the `RegisterWebMessageReceivedHandler` in C#.
     * @param message The message to send.
     */
    sendMessage(message: string): void;

    /**
     * Registers a callback function to handle messages received from the C# backend.
     * @param callback A function that receives the string message from C#.
     */
    receiveMessage(callback: (message: string) => void): void;
}
