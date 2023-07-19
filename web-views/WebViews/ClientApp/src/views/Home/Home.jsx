import React, { useEffect, useState, useRef } from "react";
import { useSelector } from "react-redux";
import { HubConnectionBuilder } from "@microsoft/signalr";
import { Card, InputGroup, Form, Spinner } from "react-bootstrap";
import EncoderInput from "../../components/Encoder/EncoderInput";

export default function Home() {
  const url = useSelector((state) => state.data.apiBaseUrl);
  const apiLoading = useSelector((state) => state.data.loading);

  const [connection, setConnection] = useState(null);
  const [connectionId, setConnectionId] = useState(null);
  const [valueToEncode, setValueToEncode] = useState(null);
  const [encodeResult, setEncodeResult] = useState("");
  const [isLoading, setIsLoading] = useState(false);

  const textAreaRef = useRef([]);

  useEffect(() => {
    if (url) {
      const newConnection = new HubConnectionBuilder()
        .withUrl(`${url}/hubs/encode`)
        .withAutomaticReconnect()
        .build();
      setConnection(newConnection);
    }
  }, [url]);

  useEffect(() => {
    if (connection) {
      connection.on("Receive", (message) => {
        setEncodeResult(textAreaRef.current.value + message);
      });
      connection.on("Complete", () => {
        setIsLoading(false);
      });
    }
  }, [connection]);

  useEffect(() => {
    if (connectionId) {
      connection.invoke("Send", valueToEncode, connectionId);
    }
  }, [connectionId]);

  const runEncoding = (value) => {
    setValueToEncode(value);
    setEncodeResult("");
    if (!connection._connectionStarted) {
      connection
        .start()
        .then(() => {
          connection.invoke("getconnectionid").then((data) => {
            setConnectionId(data);
          });
        })
        .catch((e) => {
          setIsLoading(false);
          setEncodeResult("Something went terribly wrong...");
          console.log(e);
        });
    } else {
      connection.invoke("Send", valueToEncode, connectionId);
    }
    setIsLoading(true);
  };

  const cancelEncoding = () => {
    connection.stop();
    setEncodeResult("");
    setIsLoading(false);
  };

  return (
    <Card className="encoderCard">
      <Card.Header as="h5">Encode to Base64 format</Card.Header>
      {apiLoading ? (
        <Spinner animation="border" className="encoderSpinner" />
      ) : (
        <Card.Body>
          <Card.Text>
            Simply enter your data then push the encode button.
          </Card.Text>
          <EncoderInput
            onRun={runEncoding}
            onCancel={cancelEncoding}
            isLoading={isLoading}
          />
          <InputGroup>
            <Form.Control
              as="textarea"
              aria-label="With textarea"
              placeholder="Result goes here..."
              value={encodeResult}
              readOnly
              ref={textAreaRef}
            />
          </InputGroup>
        </Card.Body>
      )}
    </Card>
  );
}
