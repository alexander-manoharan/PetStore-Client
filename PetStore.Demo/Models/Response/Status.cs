namespace PetStore.Demo.Models {
    /// <summary>
    /// Status of the pets in PetStore <see cref="Pet"/>
    /// </summary>
    public enum Status 
    {
        /// <summary>
        /// The Pet is available.
        /// </summary>
        Available,
        /// <summary>
        /// The Pet is pending.
        /// </summary>
        Pending,
        /// <summary>
        /// The Pet is sold.
        /// </summary>
        Sold
    }
}