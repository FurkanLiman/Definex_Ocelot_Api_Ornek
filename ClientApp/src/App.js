import React from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import { Container, Navbar, Nav } from 'react-bootstrap';
import ArticleList from './components/ArticleList';
import ArticleDetail from './components/ArticleDetail';
import WriterList from './components/WriterList';
import WriterDetail from './components/WriterDetail';
import Home from './components/Home';

function App() {
  return (
    <Router>
      <div className="App">
        <Navbar bg="dark" variant="dark" expand="lg">
          <Container>
            <Navbar.Brand as={Link} to="/">Definex Ocelot API Gateway</Navbar.Brand>
            <Navbar.Toggle aria-controls="basic-navbar-nav" />
            <Navbar.Collapse id="basic-navbar-nav">
              <Nav className="me-auto">
                <Nav.Link as={Link} to="/">Home</Nav.Link>
                <Nav.Link as={Link} to="/articles">Articles</Nav.Link>
                <Nav.Link as={Link} to="/writers">Writers</Nav.Link>
              </Nav>
            </Navbar.Collapse>
          </Container>
        </Navbar>

        <Container>
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/articles" element={<ArticleList />} />
            <Route path="/articles/:id" element={<ArticleDetail />} />
            <Route path="/writers" element={<WriterList />} />
            <Route path="/writers/:id" element={<WriterDetail />} />
          </Routes>
        </Container>
      </div>
    </Router>
  );
}

export default App; 