import React, { Children, useState } from "react";

function FAQSubject({ title, children }) {
  const [isOpen, setIsOpen] = useState(false);
  return (
    <div onClick={() => setIsOpen(!isOpen)}>
      <div>
        <p>{title}</p>
      </div>
      {isOpen ? (
        <div>
          <p>{children}</p>
          <p></p>
        </div>
      ) : (
        <></>
      )}
    </div>
  );
}

export default FAQSubject;
