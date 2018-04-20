require(raster)

# Create 100x100 random raster with a Z range of 500-1500
r <- raster(ncols=100, nrows=100, xmn=0)
r[] <- runif(ncell(r), min=0, max=15)  

# Gaussian Kernel Function
GaussianKernel <- function(sigma=s, n=d) {
  m <- matrix(nc=n, nr=n)
  col <- rep(1:n, n)
  row <- rep(1:n, each=n)
  x <- col - ceiling(n/2)
  y <- row - ceiling(n/2)
  m[cbind(row, col)] <- 1/(2*pi*sigma^2) * exp(-(x^2+y^2)/(2*sigma^2))
  m / sum(m)
}

# Create autocorrelated raster using 9x9 Gaussian Kernel with a sigma of 1
r.sim <- focal(r, w=GaussianKernel(sigma=1, n=9))

# Plot results
#par(mfcol=c(1,2))
#plot(r, main="Random Raster")
plot(r.sim, axes=FALSE)

r[] <- 1:ncell(r)
mtx <- as.matrix(r.sim)

