// ============================================
// 📁 views/components/Header.tsx - Header View
// ============================================

import { Link } from "react-router-dom";
import { Menu, X, Monitor } from "lucide-react";
import { Button } from "@/components/ui/button";
import { useHeaderController } from "@/controllers/useHeaderController";

const Header = () => {
  const { isMenuOpen, toggleMenu, closeMenu, navItems, isActive } = useHeaderController();

  return (
    <header className="fixed top-0 left-0 right-0 z-50 glass-card border-b">
      <div className="container mx-auto px-4">
        <div className="flex items-center justify-between h-20">
          <Link to="/" className="flex items-center gap-2 group">
            <div className="p-2 rounded-lg bg-primary/10 group-hover:bg-primary/20 transition-colors">
              <Monitor className="w-6 h-6 text-primary" />
            </div>
            <span className="text-xl font-bold text-gradient">VinMap</span>
          </Link>

          {/* Desktop Navigation */}
          <nav className="hidden md:flex items-center gap-1">
            {navItems.map((item) => (
              <Link
                key={item.path}
                to={item.path}
                className={`px-4 py-2 rounded-lg transition-colors ${
                  isActive(item.path) ? "bg-primary text-white" : "text-foreground hover:bg-secondary"
                }`}
              >
                {item.label}
              </Link>
            ))}
          </nav>

          <div className="hidden md:flex items-center gap-3">
            <Button variant="outline" size="sm">Hotline: 0123-456-789</Button>
          </div>

          {/* Mobile Menu Button */}
          <button className="md:hidden p-2" onClick={toggleMenu}>
            {isMenuOpen ? <X className="w-6 h-6" /> : <Menu className="w-6 h-6" />}
          </button>
        </div>

        {/* Mobile Navigation */}
        {isMenuOpen && (
          <nav className="md:hidden py-4 animate-fade-in">
            {navItems.map((item) => (
              <Link
                key={item.path}
                to={item.path}
                className={`block px-4 py-3 rounded-lg mb-2 ${
                  isActive(item.path) ? "bg-primary text-white" : "text-foreground hover:bg-secondary"
                }`}
                onClick={closeMenu}
              >
                {item.label}
              </Link>
            ))}
            <Button className="w-full mt-4" size="sm">Hotline: 0123-456-789</Button>
          </nav>
        )}
      </div>
    </header>
  );
};

export default Header;