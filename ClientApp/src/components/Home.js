import React from 'react';
import { Card, Button } from 'react-bootstrap';
import { Link } from 'react-router-dom';

const Home = () => {
  return (
    <div className="mt-4">
      <h1>Definex Ocelot API Gateway Demo</h1>
      <p className="lead">
        This application demonstrates the use of Ocelot API Gateway with multiple microservices.
      </p>
      
      <div className="row mt-4">
        <div className="col-md-6">
          <Card>
            <Card.Header as="h5">Articles API</Card.Header>
            <Card.Body>
              <Card.Text>
                Browse and manage articles through the API Gateway.
              </Card.Text>
              <Button as={Link} to="/articles" variant="primary">View Articles</Button>
            </Card.Body>
          </Card>
        </div>
        
        <div className="col-md-6">
          <Card>
            <Card.Header as="h5">Writers API</Card.Header>
            <Card.Body>
              <Card.Text>
                Browse and manage writers through the API Gateway.
              </Card.Text>
              <Button as={Link} to="/writers" variant="primary">View Writers</Button>
            </Card.Body>
          </Card>
        </div>
      </div>
      
      <div className="mt-4">
        <h3>Architecture</h3>
        <p>
          This application uses an Ocelot API Gateway to route requests to the appropriate microservice:
        </p>
        <ul>
          <li><strong>API Gateway:</strong> Runs on port 5003 (and 5006 for horizontal scaling)</li>
          <li><strong>Article.Api:</strong> Microservice for article management on port 5001</li>
          <li><strong>Writer.Api:</strong> Microservice for writer management on port 5002</li>
        </ul>
      </div>
    </div>
  );
};

export default Home; 