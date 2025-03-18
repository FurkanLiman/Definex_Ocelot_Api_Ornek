import axios from 'axios';

// Base API URL - using the API Gateway
const API_URL = '/gateway';

// Articles API
export const getArticles = async () => {
  const response = await axios.get(`${API_URL}/articles`);
  return response.data;
};

export const getArticleById = async (id) => {
  const response = await axios.get(`${API_URL}/articles/${id}`);
  return response.data;
};

export const createArticle = async (article) => {
  const response = await axios.post(`${API_URL}/articles`, article);
  return response.data;
};

export const updateArticle = async (id, article) => {
  const response = await axios.put(`${API_URL}/articles/${id}`, article);
  return response.data;
};

export const deleteArticle = async (id) => {
  await axios.delete(`${API_URL}/articles/${id}`);
};

// Writers API
export const getWriters = async () => {
  const response = await axios.get(`${API_URL}/writers`);
  return response.data;
};

export const getWriterById = async (id) => {
  const response = await axios.get(`${API_URL}/writers/${id}`);
  return response.data;
};

export const createWriter = async (writer) => {
  const response = await axios.post(`${API_URL}/writers`, writer);
  return response.data;
};

export const updateWriter = async (id, writer) => {
  const response = await axios.put(`${API_URL}/writers/${id}`, writer);
  return response.data;
};

export const deleteWriter = async (id) => {
  await axios.delete(`${API_URL}/writers/${id}`);
}; 