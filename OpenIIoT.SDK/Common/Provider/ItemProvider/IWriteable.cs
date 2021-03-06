﻿/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █    ▄█   ▄█     █▄
      █   ███  ███     ███
      █   ███▌ ███     ███    █████  █      ██       ▄█████   ▄█████  ▀██████▄   █          ▄█████
      █   ███▌ ███     ███   ██  ██ ██  ▀███████▄   ██   █    ██   ██   ██   ██ ██         ██   █
      █   ███▌ ███     ███  ▄██▄▄█▀ ██▌     ██  ▀  ▄██▄▄      ██   ██  ▄██▄▄█▀  ██        ▄██▄▄
      █   ███  ███     ███ ▀███████ ██      ██    ▀▀██▀▀    ▀████████ ▀▀██▀▀█▄  ██       ▀▀██▀▀
      █   ███  ███ ▄█▄ ███   ██  ██ ██      ██      ██   █    ██   ██   ██   ██ ██▌    ▄   ██   █
      █   █▀    ▀███▀███▀    ██  ██ █      ▄██▀     ███████   ██   █▀ ▄██████▀  ████▄▄██   ███████
      █
 ▄ ▄▄ █ ▄▄▄▄▄▄▄▄▄  ▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █ ██ █ █████████  ████ ██████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      █
      █  Defines the interface for Connector Plugins capable of writing data to the source of the Connector data.
      █
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██
                                                                                                   ██
                                                                                               ▀█▄ ██ ▄█▀
                                                                                                 ▀████▀
                                                                                                   ▀▀                            */

namespace OpenIIoT.SDK.Common.Provider.ItemProvider
{
    using System.Threading.Tasks;
    using OpenIIoT.SDK.Common.OperationResult;
    using OpenIIoT.SDK.Plugin.Connector;

    /// <summary>
    ///     Defines the interface for Connector Plugins capable of writing data to the source of the Connector data.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         An <see cref="IConnector"/> instance implementing IWriteable is responsible for writing data to
    ///         <see cref="ConnectorItem"/> s by way of the <see cref="Write(Item, object)"/> method. This method accepts a
    ///         ConnectorItem instance and a value boxed in an <see cref="object"/>.
    ///     </para>
    ///     <para>
    ///         The Write() method must return a valid <see cref="Result"/> containing the result of the operation, including any
    ///         informational, warning or error messages generated during the operation.
    ///     </para>
    /// </remarks>
    public interface IWriteable
    {
        #region Public Methods

        /// <summary>
        ///     Writes the specified value to the specified <see cref="Item"/>.
        /// </summary>
        /// <param name="item">The Item to write.</param>
        /// <param name="value">The value to write to the <see cref="Item"/>.</param>
        /// <returns>A value indicating whether the write operation succeeded.</returns>
        bool Write(Item item, object value);

        /// <summary>
        ///     Asynchronously writes the specified value to the specified <see cref="Item"/>.
        /// </summary>
        /// <param name="item">The Item to write.</param>
        /// <param name="value">The value to write to the <see cref="Item"/>.</param>
        /// <returns>A value indicating whether the write operation succeeded.</returns>
        Task<bool> WriteAsync(Item item, object value);

        #endregion Public Methods
    }
}