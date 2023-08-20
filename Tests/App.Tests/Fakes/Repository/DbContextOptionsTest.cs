using System.ComponentModel.DataAnnotations.Schema;

namespace App.Tests.Fakes.Repository;

/// <summary>
///     DbContext Options Test
/// </summary>
internal class DbContextOptionsTest : IDbContextOptionsTest
{
    /// <summary>
    ///     DatabaseId
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid DatabaseId { get; set; }
}