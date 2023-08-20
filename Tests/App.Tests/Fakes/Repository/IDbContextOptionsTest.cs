namespace App.Tests.Fakes.Repository;

/// <summary>
///     Interface for DbContext Options Test
/// </summary>
public interface IDbContextOptionsTest {
    
    /// <summary>
    ///     DatabaseId
    /// </summary>
    Guid DatabaseId { get; set; }
}