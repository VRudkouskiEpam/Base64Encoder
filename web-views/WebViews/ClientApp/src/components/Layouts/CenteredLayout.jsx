import React from "react";
import { Container } from "reactstrap";

export default function CenteredLayout({ children }) {
  return (
    <div className="centeredLayout">
      <div className="contentContainer">
        <Container tag="main">{children}</Container>
      </div>
    </div>
  );
}
