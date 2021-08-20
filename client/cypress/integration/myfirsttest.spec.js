describe("My First Test", function () {
  it("our app runs", function () {
    cy.visit("http://localhost:4200");
    cy.get("[data-cy=login-email]").type("stijn.vanriet@student.hogent.be");
    cy.get("[data-cy=login-password]").type("P@ssword1111");
    cy.get("[data-cy=login-button]").should("be.enabled");
    cy.get("[data-cy=login-button]").click();
    cy.get("[data-cy=appointmentCard]").should("have.length", 1);

    cy.server();
    cy.route({
      method: "GET",
      url: "/api/appointments/appointments",
      status: 200,
      response: "fixture:appointments.json",
    });
    cy.visit("/");
    cy.get("[data-cy=appointmentCard]").should("have.length", 1);
  });

  it("add an appointment", function () {
    cy.visit("http://localhost:4200");
    cy.get("[data-cy=login-email]").type("stijn.vanriet@student.hogent.be");
    cy.get("[data-cy=login-password]").type("P@ssword1111");
    cy.get("[data-cy=login-button]").should("be.enabled");
    cy.get("[data-cy=login-button]").click();

    cy.visit("/add");
    cy.get("[data-cy=makeAppointment]").should("be.disabled");
    cy.get("[data-cy=add-firstName]").type("Stijn");
    cy.get("[data-cy=add-lastName]").type("Van Riet");
    cy.get("[data-cy=add-email]").type("stijn.vanriet@student.hogent.be");
    cy.get("[data-cy=add-phoneNumber]").type("0496512796");
    cy.get("[data-cy=add-category]").click();
    cy.get("[data-cy=add-category-option]").contains("Men").click();
    cy.get("[data-cy=add-service1]").click();
    cy.get("[data-cy=add-service1-option]").contains("Trim cut: €29").click();
    cy.get("[data-cy=add-service2]").click();
    cy.get("[data-cy=add-service2-option]").contains("Coloring: €46").click();
    cy.get("[data-cy=add-service3]").click();
    cy.get("[data-cy=add-service3-option]")
      .contains("Quick shave: €26")
      .click();
    cy.get("[data-cy=add-remarks]").type("Test!");
    cy.get("[data-cy=add-date]").click();
    cy.contains("31").click();
    cy.get("[data-cy=add-time]").click();
    cy.get("[data-cy=add-time-option]").contains("08:00").click();
    cy.get("[data-cy=makeAppointment]").should("be.enabled");
    cy.get("[data-cy=makeAppointment]").click();

    cy.get("[data-cy=appointmentCard]").should("have.length", 2);
    cy.contains("Cancel").click();
    cy.get("[data-cy=appointmentCard]").should("have.length", 1);
  });

  it("add an another appointment", function () {
    cy.visit("http://localhost:4200");
    cy.get("[data-cy=login-email]").type("stijn.vanriet@student.hogent.be");
    cy.get("[data-cy=login-password]").type("P@ssword1111");
    cy.get("[data-cy=login-button]").should("be.enabled");
    cy.get("[data-cy=login-button]").click();

    cy.visit("/add");
    cy.get("[data-cy=makeAppointment]").should("be.disabled");
    cy.get("[data-cy=add-firstName]").type("Stijn");
    cy.get("[data-cy=add-lastName]").type("Van Riet");
    cy.get("[data-cy=add-email]").type("stijn.vanriet@student.hogent.be");
    cy.get("[data-cy=add-phoneNumber]").type("0496512796");
    cy.get("[data-cy=add-category]").click();
    cy.get("[data-cy=add-category-option]").contains("Men").click();
    cy.get("[data-cy=add-service1]").click();
    cy.get("[data-cy=add-service1-option]").contains("Trim cut: €29").click();
    cy.get("[data-cy=add-service2]").click();
    cy.get("[data-cy=add-service2-option]").contains("Coloring: €46").click();
    cy.get("[data-cy=add-service3]").click();
    cy.get("[data-cy=add-service3-option]")
      .contains("Quick shave: €26")
      .click();
    cy.get("[data-cy=add-remarks]").type("Test!");
    cy.get("[data-cy=add-date]").click();
    cy.contains("31").click();
    cy.get("[data-cy=add-time]").click();
    cy.get("[data-cy=add-time-option]").contains("08:45").click();
    cy.get("[data-cy=makeAppointment]").should("be.enabled");
    cy.get("[data-cy=makeAppointment]").click();

    cy.get("[data-cy=appointmentCard]").should("have.length", 2);
    cy.contains("Cancel").click();
    cy.get("[data-cy=appointmentCard]").should("have.length", 1);
  });

  it("on error should show error message", function () {
    cy.visit("http://localhost:4200");
    cy.get("[data-cy=login-email]").type("stijn.vanriet@student.hogent.be");
    cy.get("[data-cy=login-password]").type("P@ssword1111");
    cy.get("[data-cy=login-button]").should("be.enabled");
    cy.get("[data-cy=login-button]").click();
    cy.server();
    cy.route({
      method: "GET",
      url: "/api/appointments/appointments",
      status: 500,
      response: "ERROR",
    });
    cy.visit("/");
    cy.get("[data-cy=appError]").should("be.visible");
  });
});
