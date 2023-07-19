import React, { useState } from "react";
import PropTypes from "prop-types";
import { Button, InputGroup, Form, Spinner } from "react-bootstrap";

export default function EncoderInput({ onRun, onCancel, isLoading }) {
  const [inputValue, setInputValue] = useState(null);

  return (
    <>
      <InputGroup className="mb-3">
        <Form.Control
          placeholder="Type (or paste) here"
          aria-label="Type (or paste) here"
          onChange={(e) => {
            setInputValue(e.target.value);
          }}
        />
      </InputGroup>
      <Button
        onClick={() => onRun(inputValue)}
        variant="primary"
        disabled={!inputValue || isLoading}
      >
        {isLoading ? (
          <>
            <Spinner
              as="span"
              animation="grow"
              size="sm"
              role="status"
              aria-hidden="true"
            />
            Encoding...
          </>
        ) : (
          <>Encode</>
        )}
      </Button>
      <Button onClick={() => onCancel()} variant="secondary">
        Cancel
      </Button>
    </>
  );
}

EncoderInput.propTypes = {
  onRun: PropTypes.func,
  onCancel: PropTypes.func,
  isLoading: PropTypes.bool,
};
