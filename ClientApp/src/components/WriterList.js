import React, { useState, useEffect } from 'react';
import { Card, Button, Alert } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { getWriters, deleteWriter } from '../services/api';

const WriterList = () => {
  const [writers, setWriters] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  const fetchWriters = async () => {
    try {
      setLoading(true);
      const data = await getWriters();
      setWriters(data);
      setError(null);
    } catch (err) {
      console.error('Error fetching writers:', err);
      setError('Failed to load writers. Please try again later.');
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchWriters();
  }, []);

  const handleDelete = async (id) => {
    if (window.confirm('Are you sure you want to delete this writer?')) {
      try {
        await deleteWriter(id);
        // Refresh the list
        fetchWriters();
      } catch (err) {
        console.error('Error deleting writer:', err);
        setError('Failed to delete writer. Please try again.');
      }
    }
  };

  if (loading) {
    return <div>Loading writers...</div>;
  }

  if (error) {
    return <Alert variant="danger">{error}</Alert>;
  }

  return (
    <div className="mt-4">
      <h2>Writers</h2>
      <div className="d-flex justify-content-end mb-3">
        <Button as={Link} to="/writers/new" variant="success">Add New Writer</Button>
      </div>
      
      {writers.length === 0 ? (
        <Alert variant="info">No writers found</Alert>
      ) : (
        writers.map(writer => (
          <Card key={writer.id} className="mb-3">
            <Card.Header as="h5">{writer.firstName} {writer.lastName}</Card.Header>
            <Card.Body>
              <Card.Text>
                Email: {writer.email || 'Not provided'}
              </Card.Text>
              <Card.Text>
                Joined: {new Date(writer.createdDate).toLocaleDateString()}
              </Card.Text>
              <div>
                <Button as={Link} to={`/writers/${writer.id}`} variant="primary" className="me-2">View</Button>
                <Button as={Link} to={`/writers/edit/${writer.id}`} variant="secondary" className="me-2">Edit</Button>
                <Button variant="danger" onClick={() => handleDelete(writer.id)}>Delete</Button>
              </div>
            </Card.Body>
          </Card>
        ))
      )}
    </div>
  );
};

export default WriterList; 