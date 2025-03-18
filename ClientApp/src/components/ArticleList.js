import React, { useState, useEffect } from 'react';
import { Card, Button, Alert } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { getArticles, deleteArticle } from '../services/api';

const ArticleList = () => {
  const [articles, setArticles] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  const fetchArticles = async () => {
    try {
      setLoading(true);
      const data = await getArticles();
      setArticles(data);
      setError(null);
    } catch (err) {
      console.error('Error fetching articles:', err);
      setError('Failed to load articles. Please try again later.');
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchArticles();
  }, []);

  const handleDelete = async (id) => {
    if (window.confirm('Are you sure you want to delete this article?')) {
      try {
        await deleteArticle(id);
        // Refresh the list
        fetchArticles();
      } catch (err) {
        console.error('Error deleting article:', err);
        setError('Failed to delete article. Please try again.');
      }
    }
  };

  if (loading) {
    return <div>Loading articles...</div>;
  }

  if (error) {
    return <Alert variant="danger">{error}</Alert>;
  }

  return (
    <div className="mt-4">
      <h2>Articles</h2>
      <div className="d-flex justify-content-end mb-3">
        <Button as={Link} to="/articles/new" variant="success">Add New Article</Button>
      </div>
      
      {articles.length === 0 ? (
        <Alert variant="info">No articles found</Alert>
      ) : (
        articles.map(article => (
          <Card key={article.id} className="mb-3">
            <Card.Header as="h5">{article.title}</Card.Header>
            <Card.Body>
              <Card.Text>
                Published: {new Date(article.publishedDate).toLocaleDateString()}
                {article.writerId && ` | Writer ID: ${article.writerId}`}
              </Card.Text>
              <Card.Text>
                {article.content.substring(0, 150)}
                {article.content.length > 150 ? '...' : ''}
              </Card.Text>
              <div>
                <Button as={Link} to={`/articles/${article.id}`} variant="primary" className="me-2">View</Button>
                <Button as={Link} to={`/articles/edit/${article.id}`} variant="secondary" className="me-2">Edit</Button>
                <Button variant="danger" onClick={() => handleDelete(article.id)}>Delete</Button>
              </div>
            </Card.Body>
          </Card>
        ))
      )}
    </div>
  );
};

export default ArticleList; 