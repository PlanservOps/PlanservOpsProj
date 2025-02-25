import {BrowserRouter, Route, Routes } from 'react-router-dom';
import "bootstrap/dist/css/bootstrap.min.css"
import './App.css';
import Home from './pages';
import Header from './components/Header';

function App() {
  return (
    <BrowserRouter>
    <Header/>
      <Routes>
        <Route path="/" exact={true} element={<Home/>}/>
        <Route path="/home" exact={true} element={<Home/>}/>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
