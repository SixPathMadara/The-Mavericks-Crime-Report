// src/components/Footer.tsx
import React from "react";

const Footer: React.FC = () => {
  return (
    <footer>
      <div className="footer">
        <div className="footerRow">
          <div className="footerSidebar">
            <h3>About Us</h3>
            <p>
              The Mavericks group 32. Creators of Vimba the Crime Awareness Reporting System. The 
              Group consists of the following four members. SS Ngwenya (Front End & Mobile Developer)
              , KS Mashishi (Front End & Web Developer), OT Legots (Full Stack Developer), N Maseko 
              (Backend Developer & API Developer)
            </p>
          </div>
          <div className="footerSidebar">
            <h3>Connect With Us</h3>
            <ul className="social-icons">
              <li>
                <a href="#">
                  <i className="fab fa-facebook"></i>
                </a>
              </li>
              <li>
                <a href="#">
                  <i className="fab fa-twitter"></i>
                </a>
              </li>
              <li>
                <a href="#">
                  <i className="fab fa-instagram"></i>
                </a>
              </li>
              <li>
                <a href="#">
                  <i className="fab fa-linkedin"></i>
                </a>
              </li>
            </ul>
          </div>
          <div className="footerSidebar">
            <h3>Contact Us</h3>
            <p>
              Auckland Park Kingsway.
              <br />
              Johannesburg, Gauteng
            </p>
            <p>
              Phone: 555-555-5555
              <br />
              Email: mavericks@example.com
            </p>
          </div>
        </div>
      </div>
    </footer>
  );
};

export default Footer;
