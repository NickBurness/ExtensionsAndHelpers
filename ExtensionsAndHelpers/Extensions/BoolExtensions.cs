namespace ExtensionsAndHelpers
{
    public static class BoolExtensions
    {

        /// <summary>
        /// When value matches condition invokes method
        /// </summary>
        /// <param name="value">Current value of Boolean</param>
        /// <param name="executeWhen">Value of Boolean when to execute delegate.</param>
        /// <param name="method">Delegate method to execute.</param>
        public static int When(this bool value, bool executeWhen, Action method)
        {
            if (value == executeWhen)
            {
                method.Invoke();
                return 1;
            }

            return 0;
        }

        /// <summary>
        /// Executes the delegate when the boolean value is true.
        /// </summary>
        /// <param name="value">Current value of the boolean.</param>
        /// <param name="method">Delegate method to execute.</param>
        public static int WhenTrue(this bool value, Action method)
        {
            if (value)
            {
                method.Invoke();
                return 1;
            }

            return 0;
        }

        /// <summary>
        /// Executes the delegate when the boolean value is false.
        /// </summary>
        /// <param name="value">Current value of the boolean.</param>
        /// <param name="method">Delegate method to execute.</param>
        public static int WhenFalse(this bool value, Action method)
        {
            if (!value)
            {
                method.Invoke();
                return 1;
            }

            return 0;
        }
    }
}
