const currentPath = window.location.pathname.toLowerCase();
const navItems = document.getElementsByName("nav");

navItems.forEach(link => {
    const linkPath = link.getAttribute('href')?.toLowerCase() || '';
    if (
        currentPath === linkPath ||
        currentPath.startsWith(linkPath + '/') ||
        (linkPath === '/' && currentPath === '/')
    ) {
        link.classList.add('btn-primary');
        
    } else {
        link.classList.remove('btn-primary');
    }
});