namespace anticheat
{
    /// <summary>
    /// Event System to provide a possibilty to subscribe a Ban function and publish it.
    /// </summary>
    public class BanHandler
    {
        private static BanHandler _handler;

        public delegate void HandleBan();
        HandleBan _publisher;


        // Returns the Singleton Instance of the BanHandler.
        public static BanHandler GetBanHandler()
        {
            if (_handler == null)
                _handler = new BanHandler();

            return _handler;
        }

        /// <summary>
        /// Subscribes the given function to the BanHandle publisher.
        /// </summary>
        /// <param name="subscriber">The function to subscribe</param>
        /// <returns>True if the function has been subscribed successfully.</returns>
        public bool SubscribeBanHandler(HandleBan subscriber)
        {
            if (_publisher != null)
            {
                Logger.GetLogger().Log(_LOGGER_TYPE.WARNING, "You can only subscribe one instance of a Ban Handler. No additional Handler has been subscribed.");
                return false;
            }


            _publisher = subscriber;

            return true;
        }

        /// <summary>
        /// Executes the Publisher.
        /// </summary>
        public void Publish()
        {
            if (_publisher == null)
            {
                return;
            }

            _publisher();

        }

        //Returns true if a BanHandler has been subscribed.
        public bool IsConfigured()
        {
            return _publisher != null;
        }
    }
}
