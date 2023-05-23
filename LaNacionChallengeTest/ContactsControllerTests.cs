using LaNacionChallenge.Controllers;
using LaNacionChallenge.Models;
using LaNacionChallenge.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace LaNacionChallengeTest
{
    public class ContactsControllerTests
    {
        [Fact]
        public void Get_ValidId_ReturnsContact()
        {
            string contactId = "646c64ef034e90fc334dd130";
            Mock<IContactsCollection> mockContactRepository = new Mock<IContactsCollection>();
            mockContactRepository.Setup(repo => repo.GetContactById(contactId))
                .ReturnsAsync(new Contact { Id = contactId, Name = "La nación" });
            ContactsController controller = new(mockContactRepository.Object);

            Task<IActionResult> actionResult = controller.GetContactById(contactId);
            OkObjectResult okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            Contact contact = Assert.IsType<Contact>(okResult.Value);

            Assert.Equal(contactId, contact.Id);
            Assert.Equal("La nación", contact.Name);
        }
    }
}
