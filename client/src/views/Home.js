import React from 'react';

import hero from '../images/hat.jpg';

const Home = (props) => {

    const heroStyles = {
        minHeight: '95vh',
        backgroundImage: `url(${hero})`,
        backgroundRepeat: 'no-repeat',
        backgroundPosition: 'center',
        backgroundSize: 'cover'
    }

    return (
    <>
    {/* Navbar */}
    <header className="pt-2 pb-3 bg-white">
    <div className="container">
    <div className="row align-items-center">
        <div className="col-6 col-xl-2">
            <h1 className="mb-0"><a href="index.html" className="text-black h3 mb-0">Job<strong>start</strong></a></h1>
        </div>

        <div className="col-6 col-xl-10 text-right">
            <a href="/start" className="text-secondary mr-3">Sign Up</a>
            <a href="/" style={{textDecoration:'none'}}>
                <span className="rounded bg-primary py-2 px-3 text-white">Login</span>
            </a>
        </div>
    </div>
    </div>
    </header>

    {/* Main */}
    <div style={heroStyles}>
    <div className="container">
    <div className="hero-text-container row d-flex flex-column justify-content-center" style={{height:'95vh'}}>
        <h1 className="hero-text text-black">Find the <strong>talent</strong> you <br />need to succeed</h1>
        <a href="/register" className="btn btn-primary p-3 text-white mt-3" style={{fontSize:'0.9rem',width:'150px'}}>Apply now</a>
    </div>
    </div>
    </div>
    </>
    )
}

export default Home;