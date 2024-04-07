namespace PasswordValidation.Tests;

[TestClass]
public class PasswordValidatorTests
{
    [TestMethod]
    [DataRow("Abcd.123")]
    [DataRow("Abcd%1234")]
    public void GivenPassword_WhenLengthIsEightOrMore_ReturnValid(string password)
    {
        var result = PasswordValidator.Validate(password);
        
        Assert.IsTrue(result.IsValid);
        Assert.IsNull(result.Message);
    }
    
    [TestMethod]
    public void GivenPassword_WhenLengthIsLessThanEight_ReturnInvalidAndMessage()
    {
        var password = "Ab%23";
        
        var result = PasswordValidator.Validate(password);
        
        Assert.IsFalse(result.IsValid);
        Assert.AreEqual("Password must be at least 8 characters", result.Message);
    }
    
    [TestMethod]
    public void ReturnInvalidAndMessage_WhenPasswordDoesNotContainAtLeastTwoNumbers()
    {
        var password = "A,abcdefgh";
        
        var result = PasswordValidator.Validate(password);
        
        Assert.IsFalse(result.IsValid);
        Assert.AreEqual("The password must contain at least 2 numbers", result.Message);
    }
    
    [TestMethod]
    public void GivenInvalidPassword_WhenFailedMultipleConditions_ReturnAllMessages()
    {
        var password = "A+bc";
        var result = PasswordValidator.Validate(password);
        
        Assert.IsFalse(result.IsValid);
        Assert.AreEqual("Password must be at least 8 characters\nThe password must contain at least 2 numbers", result.Message);
    }
    
    [TestMethod]
    public void ReturnInvalidAndMessage_WhenPasswordDoesNotContainAtLeastOneCapitalLetter()
    {
        var password = "abcd+234";
        var result = PasswordValidator.Validate(password);
        
        Assert.IsFalse(result.IsValid);
        Assert.AreEqual("password must contain at least one capital letter", result.Message);
    }
    
    [TestMethod]
    [DataRow("Abcd1234")]
    public void ReturnInvalidAndMessage_WhenPasswordDoesNotContainAtLeastOneSpecialCharacter(string password)
    {
        var result = PasswordValidator.Validate(password);
        
        Assert.IsFalse(result.IsValid);
        Assert.AreEqual("password must contain at least one special character", result.Message);
    }
}